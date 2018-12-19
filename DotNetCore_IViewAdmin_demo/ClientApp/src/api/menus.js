import axios from '@/libs/api.request'

export const getMenuList=()=>{
    return axios.request({
        url: 'api/menu',
        // params: {
        //   user_id
        // },
        method: 'get'
      })
}

export const getBaseMenu=()=>{
    return axios.request({
        url: 'api/menu/GetBaseMenu',
        // params: {
        //   user_id
        // },
        method: 'get'
      })
}

