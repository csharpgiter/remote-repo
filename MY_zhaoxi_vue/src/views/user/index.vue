<template>
    <el-card class="box-card">
        <el-row>
            <el-form label-width="120px">
                <el-form-item label="关键字">
                    <div class="block">
                        <el-input v-model="searchquery.searchKey" style="width: 240px" placeholder="姓名，身份证号码" />
                        <el-button @click="userQuery" style="margin-left: 10px" type="primary">查询</el-button>
                    </div>
                </el-form-item>
            </el-form>
        </el-row>

        <el-row>
            <el-table :data="tableData" style="width: 100%" :row-class-name="tableRowClassName">
                <el-table-column type="index" label="序号" width="100" />
                <el-table-column prop="userName" label="姓名" width="140" />
                <el-table-column prop="age" label="年龄" />
                <el-table-column prop="sextypeDes" label="性别" />
                <el-table-column prop="entryTime" label="入职时间" width="230 " />
                <el-table-column prop="jobStatusDes" label="在职状态" />
                <el-table-column label="操作" width="300">
                    <template #default="scope">
                        <div class="mb-4">
                            <el-button size="small" @click="showinfo">详细信息</el-button>
                            <el-button size="small" type="primary" @click="unoperate1">查看考勤</el-button>
                            <el-button size="small" type="success" @click="unoperate2">发送通知</el-button>
                        </div>
                    </template>
                </el-table-column>
            </el-table>
            <div class="pagination">
                <el-config-provider :locale="zhCn">
                    <el-pagination v-model:current-page="searchquery.currentPage4"
                        v-model:page-size="searchquery.pageSize4" :page-sizes="[3, 4, 5, 6]" :size="size"
                        :disabled="disabled" :background="background" layout="total, sizes, prev, pager, next, jumper"
                        :total="searchquery.total" @size-change="handleSizeChange"
                        @current-change="handleCurrentChange">
                    </el-pagination>
                </el-config-provider>
            </div>
        </el-row>

    </el-card>

</template>
<script setup>
import { ref, onMounted } from 'vue'
import _service from '../../common/apiRequest'

const tableData = ref([])
const searchquery = ref({
    currentPage4: 1,
    pageSize4: 2,
    total: 0,
    searchKey: '',
})

onMounted(async () => {
    userQuery()
})

const handleCurrentChange = (val) => {
    userQuery()
}

const handleSizeChange = (val) => {
    userQuery()
}

const showinfo = () => {
    alert("功能开发中")
}

const unoperate1 = () => {
    alert("功能开发中")
}

const unoperate2 = () => {
    alert("功能开发中")
}

let userQuery = async () => {
    var url = `/api/UserLog/${searchquery.value.currentPage4}/${searchquery.value.pageSize4}`
    var searchingKey = searchquery.value.searchKey
    if (searchingKey != '') {

        url = `/api/UserLog/${searchquery.value.currentPage4}/${searchquery.value.pageSize4}/${searchingKey}`

    }
    // var service = axios.create({ baseURL: "https://localhost:7200" })
    var response = await _service.get(url)
    var result = response.data
    tableData.value = result.dataList
    searchquery.value.total = result.recordCount
}

</script>