<template>
  <el-card class="box-card">
    <el-row>
      <el-form :model="searchquery" label-width="120px">
        <el-form-item label="时间范围">
          <div class="block">
            <el-date-picker v-model="searchquery.searchDatetime" type="datetimerange" range-separator="To"
              start-placeholder="开始时间" end-placeholder="结束时间" />
            <el-button @click="logquery" style="margin-left: 10px" type="primary">查询</el-button>
          </div>
        </el-form-item>
      </el-form>
    </el-row>

    <el-row>
      <el-table :data="tableData" style="width: 100%" :row-class-name="tableRowClassName">
        <el-table-column prop="id" label="序号" width="100" />
        <el-table-column prop="userName" label="员工" />
        <el-table-column prop="employeeId" label="员工编号" width="280" />
        <el-table-column prop="attendanceDate" label="考勤日期" />
        <el-table-column prop="attendanceStatus" label="考勤状态" />
        <el-table-column label="操作" width="180">
          <template #default="scope">

            <el-button @click="editAttendance(scope.row)" type="primary" size="small">修改</el-button>
            <el-button @click="deleteAttendance(scope.row)" type="danger" size="small">删除</el-button>
          </template>
        </el-table-column>
      </el-table>
      <!-- <template #default="scope">
              <div style="display: flex; align-items: center">
                <el-popover :width="300"
                  popper-style="box-shadow: rgb(14 18 22 / 35%) 0px 10px 38px -10px, rgb(14 18 22 / 20%) 0px 10px 20px -15px; padding: 20px;">
                  <template #reference>
                    {{ scope.row.exception.substring(0, 5) }}...
                  </template>
                  <template #default>
                    <div class="demo-rich-conent" style="display: flex; gap: 16px; flex-direction: column">
                      <div>
                        {{ scope.row.exception }}
                      </div>
                    </div>
                  </template>
                </el-popover>
              </div>
            </template> -->
      <!-- </el-table-column> -->

      <div class="pagination">
        <el-config-provider :locale="zhCn">
          <el-pagination v-model:current-page="searchquery.currentPage4" v-model:page-size="searchquery.pageSize4"
            :page-sizes="[3, 4, 5, 6]" :size="size" :disabled="disabled" :background="background"
            layout="total, sizes, prev, pager, next, jumper" :total="searchquery.total" @size-change="handleSizeChange"
            @current-change="handleCurrentChange">
          </el-pagination>
        </el-config-provider>
      </div>

      <!-- 修改考勤记录的模态框 -->
      <el-dialog v-model="editModalVisible" title="修改考勤记录" :before-close="cancelEdit">
        <el-form :model="editAttendanceData" label-width="120px">
          <el-form-item label="员工 ID">
            <el-input v-model="editAttendanceData.employeeId" />
          </el-form-item>
          <el-form-item label="考勤日期">
            <el-date-picker v-model="editAttendanceData.attendanceDate" type="date" />
          </el-form-item>
          <el-form-item label="考勤状态">
            <el-input v-model="editAttendanceData.attendanceStatus" />
          </el-form-item>
        </el-form>
        <template #footer>
          <el-button @click="cancelEdit">取消</el-button>
          <el-button type="primary" @click="saveEdit">保存</el-button>
        </template>
      </el-dialog>
      <!-- 删除考勤记录模态框 -->
      <el-dialog v-model="deleteModalVisible" title="删除考勤记录" :before-close="cancelDelete">
        <!-- <el-form :model="editAttendanceData" label-width="120px">
          <el-form-item label="员工 ID">
            <el-input v-model="editAttendanceData.employeeId" />
          </el-form-item>
          <el-form-item label="考勤日期">
            <el-date-picker v-model="editAttendanceData.attendanceDate" type="date" />
          </el-form-item>
          <el-form-item label="考勤状态">
            <el-input v-model="editAttendanceData.attendanceStatus" />
          </el-form-item>
        </el-form> -->
        <template #footer>
          <el-button @click="cancelDelete">取消</el-button>
          <el-button type="primary" @click="confirmDelete">确认</el-button>
        </template>
      </el-dialog>
    </el-row>

  </el-card>

</template>

<script setup>
import { onMounted, ref } from 'vue';
// import axios from 'axios';
import _service from '../../common/apiRequest'
//列表绑定数据结果
const tableData = ref([])
const searchquery = ref({
  currentPage4: 1,
  pageSize4: 2,
  total: 0,
  searchDatetime: [],
})
const editModalVisible = ref(false) // 控制修改考勤记录模态框的显示与隐藏
const editAttendanceData = ref({})
const editAttendanceId = ref(null)

const deleteModalVisible = ref(false) // 控制删除考勤记录模态框的显示与隐藏
//修改按钮点击事件
const editAttendance = (attendance) => {
  editAttendanceId.value = attendance.id
  editAttendanceData.value = { ...attendance }
  editModalVisible.value = true
}
//删除按钮点击事件
const deleteAttendance = (attendance) => {
  editAttendanceId.value = attendance.id
  deleteModalVisible.value = true
}


const handleCurrentChange = (val) => {
  logquery()
}

const handleSizeChange = (val) => {
  logquery()
}


onMounted(async () => {

  logquery()

})

const logquery = async () => {
  var url = `/api/Attendance/${searchquery.value.currentPage4}/${searchquery.value.pageSize4}`
  var searchDatearray = searchquery.value.searchDatetime
  if (searchDatearray.length == 2) {
    var timestampstart = Date.parse(searchDatearray[0])
    var timestampend = Date.parse(searchDatearray[1])
    url = `/api/Attendance/${searchquery.value.currentPage4}/${searchquery.value.pageSize4}/${timestampstart / 1000}/${timestampend / 1000}`
  }
  // var service = axios.create({ baseURL: "https://localhost:7200" })
  var response = await _service.get(url)
  var result = response.data
  tableData.value = result.dataList
  searchquery.value.total = result.recordCount
}
//确定修改按钮点击事件
const saveEdit = async () => {
  try {
    await _service.put(`/api/Attendance/`, editAttendanceData.value)
    await logquery() // 刷新列表
    editModalVisible.value = false
    alert('考勤记录修改成功')
  } catch (error) {
    console.error('Error updating attendance:', error)
    alert('考勤记录修改失败')
  }
}

const cancelEdit = () => {
  editModalVisible.value = false
}

const cancelDelete = () => {
  deleteModalVisible.value = false
}

const confirmDelete = async () => {
  try {
    await _service.delete(`/api/Attendance/?Attendanceid=${editAttendanceId.value}`)
    await logquery() // 刷新列表
    deleteModalVisible.value = false
    alert('考勤记录删除成功')
  } catch (error) {
}
}
</script>

<style scoped>
.el-table .warning-row {
  --el-table-tr-bg-color: var(--el-color-warning-light-9);
}

.el-table .success-row {
  --el-table-tr-bg-color: var(--el-color-success-light-9);
}
</style>