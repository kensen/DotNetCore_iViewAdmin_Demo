<style lang="less">
  @import './login.less';
</style>

<template>
  <div class="login">
    <div class="login-con">
      <Card icon="log-in" title="欢迎登录京信标签管理系统" :bordered="false">
        <div class="form-con">
          <login-form @on-success-valid="handleSubmit"></login-form>
          <p class="login-tip">YF © 2018</p>
        </div>
      </Card>
    </div>
  </div>
</template>

<script>
import LoginForm from '_c/login-form'
import { mapActions } from 'vuex'
export default {
  components: {
    LoginForm
  },
  methods: {
    ...mapActions([
      'handleLogin',
      'getUserInfo', 
      'getMenu'     
    ]),
    handleSubmit ({ userName, password }) {
      this.handleLogin({ userName, password }).then(res => {
        // console.log(res)
        this.getUserInfo().then(res => {         
          this.$router.push({
            name: this.$config.homeName
          })
        //获取用户菜单
        this.getMenu().then()

        })
      }).catch(res=>{
       // alert("登录失败！用户名或密码不正确。")
        this.$Message.error("登录失败！用户名或密码不正确。")
      })
    }
  }
}
</script>

<style>

</style>
