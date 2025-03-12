<template>
    <div class="breadcrumb">
        <el-breadcrumb :separator-icon="ArrowRight">
            <el-breadcrumb-item v-for="v in lists" :key="v.path">
                <router-link :to="v.path">{{ v.meta.title }}</router-link>
            </el-breadcrumb-item>
        </el-breadcrumb>
    </div>
</template>

<script setup>
import { ArrowRight } from '@element-plus/icons-vue'
import { useRoute } from 'vue-router';
import { ref, onMounted,watch } from 'vue';

const route = useRoute()
const lists = ref([])//作为面包屑展示数据的数组

//监听普通类型
watch(route, (to, from) => {
    getBreadcrumb(to.matched)
})

onMounted(() => {
    getBreadcrumb(route.matched)
})

function getBreadcrumb(matched) {
    lists.value = matched;
}
</script>