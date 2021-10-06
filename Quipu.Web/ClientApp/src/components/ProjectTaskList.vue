<template>
    <q-layout>
        <q-drawer v-model="showDetails"
                  side="right"
                  bordered
                  overlay
                  :width="600">
            <div class="q-drawer-container">
                <taskdetailpreview :task="this.detailtask" 
                                   @hideDetails="showDetails = false"/>
            </div>

        </q-drawer>
        <q-page-container>
            <div class="row" style="padding:15px 30px;">
                <q-space />
                <div id="heading-options">
                    <q-btn label="All Tasks" disable no-caps icon="o_check_circle_outline" dense />
                    <q-btn label="Filter" disable no-caps icon="o_filter_list" dense />
                    <q-btn label="Sort" disable no-caps icon="o_import_export" dense />
                    <q-btn label="Customize" disable no-caps icon="o_dashboard_customize" dense />
                    <q-btn disable no-caps icon="o_more_horiz" dense />
                </div>
            </div>

            <q-table :columns="this.headercolumns"
                     :rows="this.headerrows"
                     separator="vertical"
                     style="background-color:transparent"
                     flat
                     hide-pagination>
                <template v-slot:header="props">
                    <div class="row"
                         style="margin:0px 30px;
                                border-bottom:solid 1px gray;
                                border-top:solid 1px gray;">
                        <q-th v-for="col in props.cols"
                              :key="col.name"
                              :props="props">
                            {{col.label}}
                        </q-th>
                    </div>
                </template>

                <template v-slot:body="props">
                    <q-tr :props="props">
                        <q-td id="datacell"
                              key="name"
                              :props="props"
                              colspan="100%">
                            <q-expansion-item :label="props.row.name"
                                              v-model="props.row.expanded"
                                              switch-toggle-side
                                              expand-icon-toggle
                                              dense-toggle
                                              header-style="left:0px"
                                              style=" font-size:16px; margin:10px 0px;">

                                <draggable class="list-group"
                                           :list="props.row.tasks"
                                           group="people"
                                           itemKey="name"
                                           v-bind="dragOptions"
                                           @start="drag = true"
                                           @end="drag = false;"
                                           @change="(arg) => taskfinishedmoving(arg, props.row)"
                                           handle=".handle">
                                    <template #item="{ element }">
                                       <row :id ="element.id"/>
                                    </template>

                                    <template #footer>
                                        <div class="addtaskrow" @click="addemptytask(props)">
                                            <a style="margin-left:40px;
                                                      color: darkgray;">
                                                Add task...
                                            </a>
                                        </div>
                                    </template>
                                </draggable>
                            </q-expansion-item>
                        </q-td>
                    </q-tr>
                </template>

            </q-table>

        </q-page-container>

    </q-layout>

</template>

<style scoped>
    #heading-options > .q-btn {
        margin-right: 20px;
    }

    .tablecol {
        width: 10%;
        border-right: 1px solid gray;
        min-height: 40px;
        line-height: 40px;
        padding-left: 10px;
    }

    .statuscol {
        border-right: 0px;
    }

    .taskcol {
        width: 60%;
    }

    .button {
        margin-top: 35px;
    }

    #datacell {
        padding: 0 !important;
    }

    .flip-list-move {
        transition: transform 0.5s;
    }

    .no-move {
        transition: transform 0s;
    }

    .q-table--dark tbody td:before {
        background-color: transparent;
    }    

    .headercol {
        padding-top: 0px;
        padding-bottom: 0px;
    }

    .addtaskrow {
        font-size: 14px;
        border-bottom: 0px;
        margin-left: 30px;
        margin-right: 30px;
        cursor: pointer;
        padding: 10px;
        border-top: 1px solid gray;
    }

        .addtaskrow:hover {
            background-color: RGB(255,255,255,.1);
        }

</style>

<script>
    import draggable from "vuedraggable";   
    import taskdetailpreview from "./ProjectComponents/ProjectTaskList_TaskDetailPreview"
    import row from "./ProjectComponents/ProjectTaskList_Row"
    import { RepositoryFactory } from './../repositories/RepositoryFactory'
    const TaskStatusRepo = RepositoryFactory.get('taskstatuscategories')
    const TaskRepo = RepositoryFactory.get('tasks')

    export default {
        name: "ProjectTaskList",
        components: { draggable,taskdetailpreview, row },
        props: {
            project: {},
        },
        data() {
            return {
                headercolumns: [
                    {
                        name: 'name',
                        label: 'Task Name',
                        align: 'left',
                        headerClasses: 'headercol tablecol taskcol',
                    },
                    {
                        name: 'assignee',
                        label: 'Assignee',
                        align: 'left',
                        headerClasses: 'headercol tablecol assigncol',
                    },
                    {
                        name: 'date',
                        label: 'Date',
                        align: 'left',
                        headerClasses: 'headercol tablecol datecol',
                    },
                    {
                        name: 'priority',
                        label: 'Priority',
                        align: 'left',
                        headerClasses: 'headercol tablecol prioritycol',
                    },
                    {
                        name: 'status',
                        label: 'Status',
                        align: 'left',
                        headerClasses: 'headercol tablecol statuscol',
                    }
                ],             
                headerrows: [],
                drag: false,               
                showDetails: false,
                detailtask: {},
            }
        },
        methods: {
            async fetch() {
                this.taskstatusgroups = (await TaskStatusRepo.get()).data;
                this.taskstatusgroups.forEach(group => {
                    this.headerrows.push({
                        id: group.id,
                        name: group.name,
                        expanded: true,
                        tasks: this.project.tasks.filter(task => {
                            return task.statusCategory.id === group.id
                        }),
                    });
                });
            },
            updatetask(task) {
                if (task.id > 0) {
                    TaskRepo.updateTask(task);
                }
                else {
                    TaskRepo.createTask(task);
                }
            },            
            addemptytask(category) {
                var categoryname = category.row.name;
                var matchresult = this.headerrows.filter(row => { return row.name === categoryname })[0];
                matchresult.tasks.push({
                    name: '',
                    description: '',
                    completed: false,
                    startDate: '0001-01-01T00:00:00',
                    endDate: '0001-01-01T00:00:00',
                    statusCategoryID: category.row.id,
                    projectID: this.project.id,
                });
                this.$nextTick(() => { this.$refs['nameinput'].focus(); });
            },
            taskfinishedmoving(args, group) {
                if (args.added != null) {
                    args.added.element.statusCategory = this.taskstatusgroups.filter(status => status.id === group.id)[0];
                    this.updatetask(args.added.element);
                }
            },           
        },
        computed: {
            dragOptions() {
                return {
                    animation: 200,
                    group: "description",
                    disabled: false,
                    ghostClass: "ghost"
                };
            }
        },
        mounted() {
            this.fetch();
        },
    }
</script>