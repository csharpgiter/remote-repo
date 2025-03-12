import { createRouter, createWebHistory } from 'vue-router'
import usermanageview from '../views/user/index.vue'
import Index from '../views/Index.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'Index',
      component: Index,
      children: [

        {
          path: '/home/index',
          name: 'home',
          meta: {
            title: '首页'
          },
          component: () => import('../views/home/index.vue')

        }
        ,
        {
          path:'/log',
          name: 'log',
          meta: {
            title: '日志管理'
          },
          children:[
            {
              path: '/log/operate',
              name: 'log_oprate',
              meta: {
                title: '操作日志'
              },
              component: () => import('../views/log/log_operate.vue')
            }
          ]
        },

        {
          path:'/user',
          name: 'user',
          meta: {
            title: '员工同事'
          },
          children:[
            {
              path: '/user/index',
              name: 'user_index',
              meta: {
                title: '员工管理'
              },
              component: () => import('../views/user/index.vue')
            }
          ]
        },

      

        {
          path: '/setting',
          name: 'setting',
          // route level code-splitting
          // this generates a separate chunk (About.[hash].js) for this route
          // which is lazy-loaded when the route is visited.
          component: () => import('../views/setting/setting.vue')
        },

        {
          path: '/about',
          name: 'about',
          // route level code-splitting
          // this generates a separate chunk (About.[hash].js) for this route
          // which is lazy-loaded when the route is visited.
          component: () => import('../views/AboutView.vue')
        },

        {
          path: '/attendance',
          name: 'attendance',
          component: () => import('../views/attendance/attendance.vue'),
          meta: {
            title: '考勤管理'
          },
          children: [
            {
              path: '/attendance/personal',
              name: 'personal',
              component: () => import('../views/attendance/attenpersonal.vue'),
              meta: {
                title: '个人考勤'
              }
            }
          ]
        },
       
      ]
    },

  ]
})

export default router
