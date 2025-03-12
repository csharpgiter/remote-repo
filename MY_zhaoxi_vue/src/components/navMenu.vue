<!-- 这个组件是用来封装左边菜单的部分 -->
<template>
  <el-aside width="200px" class="aside">
    <el-menu :default-active="route.path" exact class="el-menu-vertical-demo" router>
      <el-menu-item class="menu" index="/index" style="padding: 0px;">
        <div style="width: 38%;
            padding-bottom: 13px;
            height: 76%;
            padding-left: 14px">
          <el-image id="myImage" :src="mainIcon" />
        </div>
      </el-menu-item>
      <NavItem v-for="v in items" :key="v.url" :item="v" :basePath="v.url" />
    </el-menu>
  </el-aside>
</template>
<script setup>
import { useRouter, useRoute } from 'vue-router';
import { reactive } from 'vue';

import NavItem from './navItem.vue';//子组件
import mainIcon from '../components/icons/菜单图标.png';

const route = useRoute();
const items = reactive([
  {
    text: '首页',
    url: '/home/index',
    icon: 'House'
  },

  {
    text: '考勤统计',
    url: '/attendance',
    icon: 'UserFilled',
    child: [
      { text: '个人考勤', url: '/attendance/personal', icon: 'Avatar' }
    ]
  },
  {
    text: '员工同事',
    url: '/user',
    icon: "house",
    child: [
      {
        text: '员工管理', url: '/user/index', icon: 'User'
      }
    ]
  }
  ,
  {
    text: '系统日志',
    url: '/log',
    icon: 'Document',
    child: [
      { text: '操作日志', url: '/log/operate', icon: 'Document' },
    ]
  }
])

</script>