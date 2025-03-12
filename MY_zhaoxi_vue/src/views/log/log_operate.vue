<template>
  <el-card class="box-card">
    <el-row>
      <el-form :model="searchquery" label-width="120px">
        <el-form-item label="时间范围">
          <div class="block">
            <el-date-picker v-model="searchquery.searchDatetime" type="datetimerange" range-separator="To" start-placeholder="开始时间"
              end-placeholder="结束时间" />
              <el-button @click="logquery" style="margin-left: 10px" type="primary">查询</el-button>
          </div>
        </el-form-item>
      </el-form>
    </el-row>

    <el-row>
      <el-table :data="tableData" style="width: 100%" :row-class-name="tableRowClassName">
        <el-table-column type="index" label="序号" width="100" />
        <el-table-column prop="dateStr" label="时间" width="280" />
        <el-table-column prop="logger" label="Logger" />
        <el-table-column prop="message" label="消息" />
        <el-table-column prop="exception" label="Exception">
          <template #default="scope">
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
          </template>
        </el-table-column>
      </el-table>
      <div class="pagination">
        <el-config-provider :locale="zhCn">
          <el-pagination v-model:current-page="searchquery.currentPage4" v-model:page-size="searchquery.pageSize4"
            :page-sizes="[3, 4, 5, 6]" :size="size" :disabled="disabled" :background="background"
            layout="total, sizes, prev, pager, next, jumper" :total="searchquery.total" @size-change="handleSizeChange"
            @current-change="handleCurrentChange">
          </el-pagination>
        </el-config-provider>
      </div>
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
  var url = `/api/SystemLog/${searchquery.value.currentPage4}/${searchquery.value.pageSize4}`
  var searchDatearray=searchquery.value.searchDatetime
  if(searchDatearray.length==2){
    var timestampstart=Date.parse(searchDatearray[0])
    var timestampend=Date.parse(searchDatearray[1])
    url=`/api/SystemLog/${searchquery.value.currentPage4}/${searchquery.value.pageSize4}/${timestampstart/1000}/${timestampend/1000}`
    
  }
  // var service = axios.create({ baseURL: "https://localhost:7200" })
  var response = await _service.get(url)
  var result = response.data
  tableData.value = result.dataList
  searchquery.value.total = result.recordCount
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