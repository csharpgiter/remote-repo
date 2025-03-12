<template>
    <div>
        <div ref="chart" style="width: 100%; height: 300px;"></div>
    </div>
</template>

<script setup>

import {ref ,reactive, onMounted,watch} from 'vue'
import * as echarts from 'echarts'

const data = defineProps({
  // const { chartType, chartData, chartxAxis, color, title } = defineProps({
  chartType: {
    type: String
  },
  chartData: {
    type: Array
  },
  chartxAxis: {
    type: Array
  },
  color: {
    type: String
  },
  title: {
    type: String
  }
})

//监听chartdata
watch( () => data.chartData, (newVal, oldVal) => {
  console.log("事件驱动");
  console.log(data);
  data.chartData = newVal
  init()
})

//创建一个DOM引用
const chart = ref( )

onMounted( () => {

  init();
})

function init() {
  // 基于准备好的dom，初始化echarts实例
  let myChart = echarts.init(chart.value);

  // 指定图表的配置项和数据
  var option = {
    title: {
      text: data.title,
      left: 'center',
      textStyle: {
        color: '#fff',
      }
    },
    color: data.color,
    tooltip: {},
    xAxis: {
      data: data.chartxAxis,
      axisLine: {  //坐标轴轴线相关设置
        lineStyle: { //坐标轴线线样式
          color: '#fff'
        }
      },
    },
    yAxis: {
      axisLine: {  //坐标轴轴线相关设置
        lineStyle: { //坐标轴线线样式
          color: '#fff'
        }
      },
    },
    grid: { //直角坐标系内绘图网格
      containLabel: true, //grid 区域是否包含坐标轴的刻度标签。
      left: '2%',
      right: '2%',
      top: '15%',
      bottom: '2%',
    },
    series: [
      {
        name: '销量',
        smooth: true,
        type: data.chartType,
        data: data.chartData
      }
    ]
  };
  // 使用刚指定的配置项和数据显示图表。
  myChart.setOption(option);
  // 响应式
  window.addEventListener("resize", () => {
    myChart.resize();
  })
}
</script>