import Vue from 'vue'
import VueRouter from 'vue-router'
import EmployeeLayout from '@/components/layout/employee/EmployeeLayout'
import DevelopLayout from '@/components/layout/DevelopLayout'
Vue.use(VueRouter)

export const router = new VueRouter({
    mode: 'history',
    routes: [
        {path: '/Employee', component: EmployeeLayout},
        {path: '/Developing', component: DevelopLayout}
    ]
})