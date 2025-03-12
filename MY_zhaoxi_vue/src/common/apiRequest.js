import { baseurl} from "./index";
import axios from "axios";



const service= axios.create({
    baseURL:baseurl(),
})
//config => {} 是一个接收 config 参数的箭头函数定义。
//config = () => {} 是将一个无参数的箭头函数赋值给变量 config 的赋值语句。两者的功能和使用场景完全不同。
service.interceptors.request.use(config=>{
console.log("请求已经发出");
return config

})

service.interceptors.response.use(async response=>{
    console.log("请求已经响应");
    return response
},error=>{
    return Promise.reject(error)
}
)


export default service;