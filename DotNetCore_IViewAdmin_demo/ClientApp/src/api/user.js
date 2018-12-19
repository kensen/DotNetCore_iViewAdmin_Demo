import axios from '@/libs/api.request'

export const login = ({ userName, password }) => {
  const data = {
    userName,
    password
  }
  return axios.request({
    url: 'api/LoginAccess/Login',
    data,
    method: 'post'
  })
}

 export const getUser = (id) => {
   return axios.request({
     url: 'api/User/GetUser',
     params: {
       id
     },
     method: 'get'
   })
 }

export const getUserPage = (index) => {
  return axios.request({
    url: 'api/User/GetPage',
    params: {
      index: index
    },
    method: 'get'
  })
}


export const addUser = (userDto) => {
  const data = userDto
  return axios.request({
    url: 'api/User/AddUser',
    data,
    method: 'post'
  })
}

export const updateUser = (userDto) => {
  const data = userDto
  return axios.request({
    url: 'api/User/UpdateUser',
    data,
    method: 'put'
  })
}

export const delUser = (ids) => {
  //const data = UserDto
  return axios.request({
    url: 'api/User/DeleteUser',
    params: {
      ids: ids
    },
    method: 'delete'
  })
}

export const logout = (token) => {
  return axios.request({
    url: 'logout',
    method: 'post'
  })
}
