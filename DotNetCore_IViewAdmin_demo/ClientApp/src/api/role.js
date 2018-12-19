import axios from '@/libs/api.request'

export const getRolesPage = (index) => {
    return axios.request({
        url: 'api/Role/GetPage',
        params: {
            index:index
        },
        method: 'get'
    })
}

export const getRole = (roleid) => {
    return axios.request({
        url: 'api/Role/GetRole',
        params: {
            id:roleid
        },
        method: 'get'
    })
}

export const getRoleList = () => {
  return axios.request({
    url: 'api/Role/GetAll',
    method: 'get'
  })
}

export const addRole = (roleDto) => {
    const data = roleDto
    return axios.request({
        url: 'api/Role/AddRole',
        data,
        method: 'post'
    })
}

export const updateRole = (roleDto) => {
    const data = roleDto
    return axios.request({
        url: 'api/Role/UpdateRole',
        data,
        method: 'put'
    })
}

export const delRole = (ids) => {
    //const data = roleDto
    return axios.request({
        url: 'api/Role/DeleteRole',
        params: {
            ids:ids
        },
        method: 'delete'
    })
}
