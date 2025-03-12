<template>
   <div class="module-box">
        <!-- 1行等5等分 -->
        <div @click="goto(item.url)" class="box" :style="`flex: 0 1 ${100/lists.length}%;margin:5px;cursor: pointer;` "
        v-for="(item,i) in lists" :key="i" >
            <div class="list-box">
                <i ><el-icon>
                        <component :is="item.icon"></component>
                    </el-icon></i>
                <p>{{ item.title }}</p>
            </div>
        </div>
    </div>

    <div class="module-box">
        <div style="flex: 0 1 30%;margin:5px;">
            <el-card class="box-card">
                <chart :chartData="materialData.chartData" :chartType="materialData.chartType" :chartxAxis="materialData.chartxAxis" :title="materialData.title" :color="materialData.color" />
            </el-card>
        </div>
        <div style="flex: 0 1 70%;margin:5px;">
            <el-card class="box-card">
                <chart :title="productSales.title" :chartType="productSales.chartType" :chartData="productSales.chartData"
                    :chartxAxis="productSales.chartxAxis" :color="productSales.color" />
                     
                <!-- <Chart :title="productSales.title" :chartType="productSales.chartType" :chartData="productSales.chartData"
                    :chartxAxis="productSales.chartxAxis" :color="productSales.color" /> -->
            </el-card>
        </div>
    </div>
    <div class="module-box">
        <!-- 1行等1等分 -->
        <div style="flex: 0 1 100%;margin:5px;">
            <el-card class="box-card" @click="">
                <chart :title="'设备运行数据'" :chartType="'line'"
                    :chartData="[1000, 1100, 800, 780, 850, 1500, 1670, 1275, 900, 600, 780, 850, 1100, 1240]"
                    :chartxAxis="['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月']"
                    :color="'#ea8052'" />
                    <!-- <Chart :title="production.title" :chartType="production.chartType" :chartData="production.chartData"
                    :chartxAxis="production.chartxAxis" :color="production.color" /> -->

            </el-card>
        </div>
    </div>
</template>

<script setup>
import{
    ChromeFilled,
    Opportunity,
    SwitchFilled,
    TrendCharts,
    VideoCameraFilled
} from '@element-plus/icons-vue'

import { ref,onMounted} from 'vue'
import router from '../../router/index'
import chart from './chart.vue'
import _service from '../../common/apiRequest.js'
// import Chart from '../components/chart.vue'

onMounted(async()=>{
    Showstatistic()
    ShowproductSales()
})

const lists = ref([
    { title: '设备运行', icon: ChromeFilled, url: "/user/index" },
    { title: '产品质检', icon: Opportunity, url: "" },
    { title: '物料详情', icon: SwitchFilled, url: "" },
    { title: '车辆监控', icon: TrendCharts, url: "" },
    { title: '统计分析', icon: VideoCameraFilled, url: "" }
])

const materialData=ref({
    title:'',
    chartData:[],
    chartxAxis:[],
    color:"",
    chartType:''
})

const productSales=ref({
    title:'',
    chartData:[],
    chartxAxis:[],
    color:"",
    chartType:''
})

const goto = (url) => {
    router.push({path: url})
}

const Showstatistic = async() => {
    var url="/api/Statistics/materialstatistic"
    var res=await _service.get(url)
    materialData.value=res.data.data
}

const ShowproductSales = async() => {
    var url="/api/Statistics/GoodStatistic"
    var res=await _service.get(url)
    productSales.value=res.data.data
}
</script>