import { createApp } from 'vue'

import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'

// import './assets/main.css'
import './style.css'//自定义的全局样式

import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import * as ElementPlusIconsVue from '@element-plus/icons-vue'
import zhCn from 'element-plus/es/locale/lang/zh-cn'//引入中文语言包

const app = createApp(App)

for (const [key, component] of Object.entries(ElementPlusIconsVue)) {
    app.component(key, component)
  }
  
app.use(createPinia())
app.use(router)

app.use(ElementPlus,{
  locale:zhCn,
})  // 全局引入element-plus

app.mount('#app')
