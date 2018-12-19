<template>
  <Row>
    <Col span="24">
      <h2 style="    margin: 10px 15px;">角色修改</h2>
      <Form ref="formValidate" :model="formValidate" :rules="ruleValidate" :label-width="80">
        <Card dis-hover>
          <p slot="title">角色信息</p>
          <FormItem label="角色名称" prop="roleName">
            <Input v-model="formValidate.roleName" placeholder="请输入角色名称" />
          </FormItem>
          <FormItem label="角色描述" prop="description">
            <Input v-model="formValidate.description" type="textarea" :autosize="{minRows: 2,maxRows: 5}" placeholder="请输入角色描述" />
          </FormItem>     
        
         </Card>
         <Card dis-hover>
          <p slot="title">权限设置</p>
          <div>
          <Card v-for="item in menuSetting" :key="item.name" :title="item.meta.title" icon="ios-options" :padding="0" shadow style="width: 300px;float:left;padding-left:10px;">
                <CellGroup>  
                  <Cell v-for="ch in item.children" :key="ch.name" :title="ch.meta.title"  >
                        <i-switch v-model="ch.show" slot="extra" size="large" >
                          <span slot="open">开启</span>
                          <span slot="close">关闭</span>
                        </i-switch>
                    </Cell>             
                    
                </CellGroup>
            </Card>
          </div>   
          
          <div style="clear:both"></div>
        </Card>
        <Card dis-hover>
            <FormItem >             
              <Button type="primary" @click="handleSubmit('formValidate')">提交</Button>
              <Button @click="handleReset('formValidate')" style="margin-left: 8px">重置</Button>
            </FormItem>
        </Card>
        
      </Form>
     
   
    </Col>
    
  </Row>
 

</template>
<script>

import { getRole,updateRole } from '@/api/role'
import {getBaseMenu} from '@/api/menus'

  export default {
    data() {
      return {
       
        formValidate: {
          roleName: '',
          description: '',
          authority: '',
          isDeleted:false,
          createdTime:'',
          updateTime:''
        },
        menuSetting:[],
        ruleValidate: {
          roleName: [
            { required: true, message: '角色名称不能为空', trigger: 'blur' }
          ]
          
        }
      }
    },
    watch:{
      "$route":"getRoleInfo"    //后面是methods中的一个方法
    },
    methods: {
      handleSubmit(name) {
        this.$refs[name].validate((valid) => {
          if (valid) {
            
            this.setAuthority()
            this.formValidate.Authority=JSON.stringify(this.menuSetting);
            updateRole(this.formValidate).then(res => {
              const data = res.data
              console.log(data)
              if(data.data){
                 this.$Message.success(data.message)
                 //this.$refs[name].resetFields();
              }else{
                this.$Message.error("操作失败："+data.message)
              }
             
            }).catch(err => {
               this.$Message.error('程序出错，更新失败')
            })
            

            //this.$Message.success('创建成功!');
          } else {
            this.$Message.error('校验失败!');
          }
        })
      },
      handleReset(name) {
        //this.$refs[name].resetFields();
       this.getRoleInfo()
      },
      getRoleInfo(){
        getRole(this.$route.params.id).then(res=>{
          this.formValidate=res.data.data
          
          if(this.formValidate.authority!="" && this.formValidate.authority!=null){
           
            this.menuSetting=JSON.parse(this.formValidate.authority);
          }else{
            getBaseMenu().then(res=>{
                this.menuSetting=res.data;
              })
          }

        })
      },
      setAuthority(){
        console.log("set")
        this.menuSetting.forEach(pitem => {
           pitem.show=false
           pitem.children.forEach(citem=>{
             if(citem.show){
               pitem.show=true               
             }
           })
        });
         console.log(this.menuSetting)
      }
    },
    created() {
      //console.log(this.$route.params.id)
        this.getRoleInfo()
      
    }
    
      
  }
</script>
