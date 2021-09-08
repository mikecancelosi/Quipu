<template>
   <q-layout>
       <q-page-container style="padding:15px 30px;">
           <div class="row">
               <q-btn-dropdown label="Add new"
                               icon="o_add"
                               color="primary"
                               split
                               dense
                               disable-dropdown>
                   <q-list>
                       <q-item clickable v-close-popup>
                           <q-item-section>
                               <q-item-label>
                                   Add Task
                               </q-item-label>
                           </q-item-section>
                       </q-item>
                       <q-item clickable v-close-popup>
                           <q-item-section>
                               <q-item-label>
                                   Add Section
                               </q-item-label>
                           </q-item-section>
                       </q-item>
                   </q-list>
               </q-btn-dropdown>

               <q-space/>

               <q-btn label="All Tasks" disable no-caps icon="o_check_circle_outline" dense/> 
               <q-btn label="Filter" disable no-caps icon="o_filter_list" dense/> 
               <q-btn label="Sort" disable no-caps icon="o_import_export" dense/> 
               <q-btn label="Customize" disable no-caps icon="o_dashboard_customize" dense/> 
               <q-btn disable no-caps icon="o_more_horiz" dense/> 
           </div>
       </q-page-container>
   </q-layout>
        
</template>

<style scoped>
    .row > .q-btn{
        margin-right:20px;
    }
</style>

<script>
    import axios from 'axios'

    export default {
        name: "ProjectTaskList",
        props: {
            team: {},
        },
        data() {
            return {
                sections: ["To Do","Doing", "Done"],
            }
        },
        methods: {
            getProjects() {
                axios.get('http://127.0.0.1:5000/api/Projects')
                    .then((response) => {
                        this.loading = false;
                        this.rows = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            openNav() {
                this.$emit("open-nav");
            },
            navigateToProject(evt, row) {
                console.log(row.id);
                this.$router.push('/Projects/' + row.id);
            }
        },
        mounted() {
            this.getProjects();
        }
    }
</script>