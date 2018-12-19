<template>
  <Row>
    <Col span="24">
    <h2 style="    margin: 10px 15px;">新增用户</h2>
    <Form ref="formValidate" :model="formValidate" :rules="ruleValidate" :label-width="80">
      <Card>
        <p slot="title">用户信息</p>
        <FormItem label="用户名称" prop="userName">
          <Input v-model="formValidate.userName" placeholder="请输入用户名称" />
        </FormItem>
        <FormItem label="登录ID" prop="loginId">
          <Input v-model="formValidate.loginId" :autosize="{minRows: 2,maxRows: 5}" placeholder="请输入登录ID" />
        </FormItem>
        <FormItem label="角色" prop="roleId">
          <Select v-model="formValidate.roleId">
            <Option value="">请选择</Option>
           <Option v-for="role in roleList" :key="role.id" :value="role.id">{{role.roleName}}</Option>            

          </Select>
        </FormItem>
        <FormItem>
          <Button type="primary" @click="handleSubmit('formValidate')">提交</Button>
          <Button @click="handleReset('formValidate')" style="margin-left: 8px">重置</Button>
        </FormItem>
      </Card>

    </Form>


    </Col>

  </Row>


</template>
<script>

  import { updateUser, getUser } from '@/api/user'
  import { getRoleList } from '@/api/role'

  export default {
    data() {
      return {
        roleList: [],
        formValidate: {
          userName: '',
          loginId: '',
          passWord: '',
          isDeleted: false,
          createdTime: '',
          roleId: ''
        },
        ruleValidate: {
          userName: [
            { required: true, message: '用户名称不能为空', trigger: 'blur' }
          ],
          loginId: [
            { required: true, message: '登录ID不能为空', trigger: 'blur' }
          ]

        }
      }
    },
    watch:{
      "$route":"getUserInfo"    //后面是methods中的一个方法
    },
    methods: {
      handleSubmit(name) {
        this.$refs[name].validate((valid) => {
          if (valid) {
            updateUser(this.formValidate).then(res => {
              const data = res.data
              console.log(data)
              if (data.data) {
                this.$Message.success(data.message)
                //this.$refs[name].resetFields();
              } else {
                this.$Message.error("操作失败：" + data.message)
              }

            }).catch(err => {
              this.$Message.error('程序出错，添加失败')
            })


            //this.$Message.success('创建成功!');
          } else {
            this.$Message.error('校验失败!');
          }
        })
      },
      handleReset(name) {
        //this.$refs[name].resetFields();
        this.getUserInfo()
      },
      getUserInfo() {
        getUser(this.$route.params.id).then(res => {
          this.formValidate = res.data.data       

        })
      }
    },
    created() {
      //console.log()
        getRoleList().then(res => {
         console.log(res)
         this.roleList = res.data.data;
         
        })

      this.getUserInfo()
    }
  }
</script>
