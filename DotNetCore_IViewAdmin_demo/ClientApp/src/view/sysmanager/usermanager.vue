<template>
  <div>
    <h2 style="    margin: 10px 15px;">用户管理</h2>
    <Card>
      <p slot="title" style="height:35px">
        <Button type="primary" @click="createUser">添加</Button>&nbsp;&nbsp; <Button type="error" @click="modal12=true">删除</Button>
        <br></br>
      </p>
      <Table ref="userData" :data="tableData1" :columns="tableColumns1" @on-selection-change="selectionChange" stripe></Table>
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
        <p>确定要删除选中的用户吗？</p>

      </div>
      <div slot="footer">
        <Button type="error" size="large" long :loading="modal_loading" @click="deleteUser">删除</Button>
      </div>
    </Modal>

  </div>

</template>
<script>

  import { getUserPage, delUser } from '@/api/user'  
  export default {
    data() {
      return {
        modal12: false,
        modal_loading: false,
        tableData1: [],
        allTotal: 0,
        tableColumns1: [
          {
            type: 'selection',
            width: 60,
            align: 'center'
          },
          {
            title: '用户名',
            key: 'userName'
          },
          {
            title: '登录ID',
            key: 'loginId'
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
                        name: 'userupdate',
                        params: {
                          id: item.row.id
                        },
                        meta: {
                          title: '用户修改-${item.row.id}'
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
        selectionRow: ""
      }
    },
    methods: {
      getPageTable(index) {
        getUserPage(index).then(res => {
          const data = res.data
          console.log(data.data)
          //this.$refs['pages'].current=res.data.total;
          this.allTotal = data.total;
          this.tableData1 = data.data;
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
        this.selectionRow = "";
        e.forEach(element => {
          this.selectionRow += element.id + ","
        });
        this.selectionRow = this.selectionRow.substring(0, this.selectionRow.lastIndexOf(','))
        console.log(this.selectionRow)

      },
      createUser() {
        const route = {
          name: 'useradd',
          meta: {
            title: '新增用户'
          }
        }
        this.$router.push(route)
      },
      deleteUser() {
        //console.log(this.selection)
        this.modal_loading = true;
        var ids = this.selectionRow;
        if (ids.length < 1) {
          this.$Message.error('没有选择要删除的数据！');
          this.modal12 = false;
          this.modal_loading = false;
          return false;
        }
        delUser(ids).then(res => {
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

          return false;

        }).catch(err => {
          this.$Message.error('程序出错，添加失败');
          console.log(err);
          this.modal12 = false;
          this.modal_loading = false;
          return false;
        })       
      }
    },
    created() {
      console.log("created")
      this.getPageTable(1)

    }
  }
</script>
