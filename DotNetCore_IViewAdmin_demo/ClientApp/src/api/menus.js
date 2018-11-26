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

