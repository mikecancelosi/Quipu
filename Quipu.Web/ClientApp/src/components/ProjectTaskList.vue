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

               <q-space />

               <q-btn label="All Tasks" disable no-caps icon="o_check_circle_outline" dense />
               <q-btn label="Filter" disable no-caps icon="o_filter_list" dense />
               <q-btn label="Sort" disable no-caps icon="o_import_export" dense />
               <q-btn label="Customize" disable no-caps icon="o_dashboard_customize" dense />
               <q-btn disable no-caps icon="o_more_horiz" dense />
           </div>

           <div class="col">
               <div class="col-3">
                   <h3>To Do</h3>
                   <draggable class="list-group"
                              :list="list1"
                              group="people"
                              @change="log"
                              itemKey="name">
                       <template #item="{ element, index }">
                           <div class="list-group-item">{{ element.name }} {{ index }}</div>
                       </template>
                   </draggable>
               </div>

               <div class="col-3">
                   <h3>Doing</h3>
                   <draggable class="list-group"
                              :list="list2"
                              group="people"
                              @change="log"
                              itemKey="name">
                       <template #item="{ element, index }">
                           <div class="list-group-item">{{ element.name }} {{ index }}</div>
                       </template>
                   </draggable>
               </div>
           </div>

       </q-page-container>
   </q-layout>
        
</template>

<style scoped>
    .row > .q-btn{
        margin-right:20px;
    }

    .buttons {
        margin-top: 35px;
    }

</style>

<script>
    import axios from 'axios'
    import draggable from "vuedraggable";

    export default {
        name: "ProjectTaskList",
        components: { draggable },
        props: {
            team: {},
        },
        data() {
            return {
                sections: ["To Do", "Doing", "Done"],
                list1: [
                    { name: "John", id: 1 },
                    { name: "Joao", id: 2 },
                    { name: "Jean", id: 3 },
                    { name: "Gerard", id: 4 }
                ],
                list2: [
                    { name: "Juan", id: 5 },
                    { name: "Edgard", id: 6 },
                    { name: "Johnson", id: 7 }
                ]
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
            add: function () {
                this.list.push({ name: "Juan" });
            },
            replace: function () {
                this.list = [{ name: "Edgard" }];
            },
            clone: function (el) {
                return {
                    name: el.name + " cloned"
                };
            },
            log: function (evt) {
                window.console.log(evt);
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