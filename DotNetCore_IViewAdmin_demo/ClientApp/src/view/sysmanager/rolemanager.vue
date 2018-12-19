<template>
  <div>
    <h2 style="    margin: 10px 15px;">角色管理</h2>
    <Card>
      <p slot="title" style="height:35px">
      <Button type="primary" @click="createRole">添加</Button>&nbsp;&nbsp; <Button type="error" @click="modal12=true">删除</Button>
      <br></br></p>
      <Table ref="roleData" :data="tableData1" :columns="tableColumns1" @on-selection-change="selectionChange" stripe></Table>
      <div style="margin: 10px;overflow: hidden">
        <div style="float: right;">
          <Page ref="pages" :total="allTotal" :current="1" @on-change="changePage"></Page>
        </div>
      </div>
    </Card>

    <Modal v-model="modal12" :mask-closable="false" width="360">
        <p slot="header" style="color:#f60;text-align:center">
            <Icon type="ios-information-circle"></Icon>
            <span>删除确认</span>
        </p>
        <div style="text-align:center">
            <p>确定要删除选中的角色吗？</p>
           
        </div>
        <div slot="footer">
            <Button type="error" size="large" long :loading="modal_loading" @click="deleteRole">删除</Button>
        </div>
    </Modal>

  </div>

</template>
<script>

  import { getRolesPage, delRole } from '@/api/role'
  export default {    
    data() {
      return {
        modal12: false,
        modal_loading: false,
        tableData1: [],
        allTotal:0,
        tableColumns1: [
          {
            type: 'selection',
            width: 60,
            align: 'center'
          },
          {
            title: '角色',
            key: 'roleName'
          },
          {
            title: '描述',
            key: 'description'          
          },
          {
            title: '创建时间',
            key: 'createdTime'            
          },
          {
            title: '编辑',
            key: 'edit',
            align: 'center',
            render: (h, item) => {
              return h('div', [
                h('Button', {
                  props: {
                    type: 'primary',
                    size: 'small'
                  },
                  style: {
                    marginRight: '5px'
                  },
                  on: {
                    click: () => {
                     // this.show(params.index)
                     const route = {
                        name: 'roleupdate',
                        params: {
                          id: item.row.id
                        },
                        meta: {
                          title: '角色修改-${item.row.id}'
                        }
                      }
                      this.$router.push(route)
                    }
                  }
                }, '修改')
              ]);
            }
          }   
         
        ],
        selectionRow:""
      }
    },
    methods: {
      getPageTable(index) {             
         getRolesPage(index).then(res=>{
            const data = res.data
             console.log(data.data)
            //this.$refs['pages'].current=res.data.total; 
              this.allTotal=data.total;      
             this.tableData1= data.data;
         }).catch(err => {
               this.$Message.error('程序出错，添加失败')
            })
      },
      formatDate(date) {
        const y = date.getFullYear();
        let m = date.getMonth() + 1;
        m = m < 10 ? '0' + m : m;
        let d = date.getDate();
        d = d < 10 ? ('0' + d) : d;
        return y + '-' + m + '-' + d;
      },
      changePage(index) {
        // The simulated data is changed directly here, and the actual usage scenario should fetch the data from the server
        console.log(index)      
        console.log(this.$refs.pages)
         this.getPageTable(index);
      },
      selectionChange(e) {
       //this.$refs.roleData
       // console.log(e);
        console.log("xx");       
        this.selectionRow="";
        e.forEach(element => {
          this.selectionRow+=element.id+","
        });
            this.selectionRow= this.selectionRow.substring(0,this.selectionRow.lastIndexOf(','))
            console.log(this.selectionRow)

      },
      createRole() {       
        const route = {
          name: 'roleadd',         
          meta: {
            title: '增加角色'
          }
        }
        this.$router.push(route)
      },
      deleteRole(){
        //console.log(this.selection)
        this.modal_loading = true;
        var ids = this.selectionRow;
        if(ids.length<1){
           this.$Message.error('没有选择要删除的数据！');
          this.modal12 = false;
            this.modal_loading = false;
            return false;
        }
        delRole(ids).then(res => {
          const data = res.data
         // console.log(data)
          if (data.data) {
            console.log(this.$refs.pages.currentPage);
            this.$Message.success(data.message);
            this.getPageTable(this.$refs.pages.currentPage);
            this.modal12 = false;
            this.modal_loading = false;         
          } else {
            this.$Message.error("操作失败：" + data.message);
           this.modal_loading = false;          
          }

          return false ;

        }).catch(err => {
          this.$Message.error('程序出错，添加失败');
           console.log(err);
          this.modal12 = false;
            this.modal_loading = false;
             return false ;
        })
                //setTimeout(() => {
                //    this.modal_loading = false;
                //  this.modal12 = false;
                //    this.$Message.success('Successfully delete');
                //}, 2000);
      }
    },
    created(){
     console.log("created")
     this.getPageTable(1)
      
    }
  }
</script>
