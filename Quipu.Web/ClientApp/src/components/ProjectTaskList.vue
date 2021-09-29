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
                        <q-td key="name"
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
                                        <div class="list-row row" style="padding:0px 30px">
                                            <q-icon name="o_drag_indicator"
                                                    class="handle"
                                                    @click="element.fixed = !element.fixed"
                                                    style="position:absolute; left:5px"
                                                    size="20px" />
                                            <div class="list-row-noicon row">
                                                <div class="tablecol taskcol">
                                                    <namecell :task="element"
                                                               @detailTask="showdetailtask(element)"
                                                              @updateTask="(name,completed)=>assignname(element,name,completed)" />
                                                </div>

                                                <div class="tablecol assigncol">
                                                    <assigneecell :task="element"
                                                                  @updateTask="(newuser) => assignuser(element,newuser)" />
                                                </div>

                                                <div class="tablecol datecol">

                                                    <datecell :task="element"
                                                              @updateTask="(startDate,endDate) => assigndates(element,startDate,endDate)" />

                                                </div>

                                                <div class="tablecol prioritycol">
                                                    <prioritycell :task="element"
                                                                  :priorityoptions=" this.priorityoptions"
                                                                  @updateTask="(priority) => assignpriority(element,priority)" />

                                                </div>

                                                <div class="tablecol statuscol">
                                                    <statuscell :task="element"
                                                                @updateTask="(status) => assignstatus(element,status)"
                                                                :statusoptions="this.statusoptions"/>
                                                </div>
                                            </div>

                                        </div>
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

    .button {
        margin-top: 35px;
    }  

    .q-td {
        padding: 0;
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

    .list-row {
        min-height: 40px;
        align-items: center;
    }

    .q-field__marginal {
        min-height: 0px;
    }

    .list-row .q-icon {
        cursor: grab;
        visibility: hidden
    }

    .list-row:hover .q-icon {
        visibility: visible
    }

    .list-row-noicon {
        border-top: 1px solid gray;
        position: relative;
        width: 100%;
        font-size: 14px;
    }

        .list-row-noicon .tablecol:hover {
            background-color: RGB(255,255,255,.1);
        }

    .headercol {
        padding-top: 0px;
        padding-bottom: 0px;
    }

    .tablecol {
        width: 10%;
        border-right: 1px solid gray;
        min-height: 40px;
        line-height: 40px;
        padding-left: 10px;
    }

    .taskcol {
        width: 60%;
    }

    .assigncol {
    }

    .datecol {
    }

    .prioritycol {
    }

    .statuscol {
        border-right: 0px;
    }

    .q-badge {
        font-size: 12px;
        padding: 5px 10px;
        width: fit-content;
    }

    .q-list {
        min-width: 200px;
    }

    .q-item .q-icon {
        align-self: center;
        margin-right: 10px;
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

<style>
    .q-field__control-container {
        max-height: 20px;
    }

    .q-focus-helper{
        opacity:0 !important;

    }

        .q-focus-helper ::before {
            opacity: 0 !important;
        }
        .q-focus-helper ::after {
            opacity: 0 !important;
        }

    .cell{
        height:100%;
        width:100%;
    }

    .q-drawer--right.q-drawer--bordered {
        top: 100px;
    }

</style>

<script>
    import axios from 'axios'
    import draggable from "vuedraggable";
    import assigneecell from "./ProjectComponents/ProjectTaskList_AssigneeCell"
    import datecell from "./ProjectComponents/ProjectTaskList_DateCell"
    import prioritycell from "./ProjectComponents/ProjectTaskList_PriorityCell"
    import statuscell from "./ProjectComponents/ProjectTaskList_StatusCell"
    import namecell from "./ProjectComponents/ProjectTaskList_NameCell"
    import taskdetailpreview from "./ProjectComponents/ProjectTaskList_TaskDetailPreview"


    export default {
        name: "ProjectTaskList",
        components: { draggable, assigneecell, datecell, prioritycell, statuscell, namecell, taskdetailpreview },
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
                statustypes: [],               
                headerrows: [],
                drag: false,
                statusoptions: [],
                prioritytypes: [],
                priorityoptions: [],
                taskstatusgroups: [],
                showDetails: false,
                detailtask: {},
            }
        },
        methods: {
            getRows() {
                //Get groups
                this.headerrows = [];
                this.taskstatusgroups = [];
                axios.get('http://127.0.0.1:5000/api/TaskStatusCategories')
                    .then((response) => {
                        this.taskstatusgroups = response.data;
                        this.taskstatusgroups.forEach(group => {
                            this.headerrows.push({
                                id: group.id,
                                name: group.name,
                                expanded: true,
                                priorityhover: false,
                                statushover: true,
                                assigneehover: false,
                                assigneedropdown: false,
                                datehover: false,
                                datedropdown: false,
                                tasks: this.project.tasks.filter(task => {
                                    return task.statusCategory.id === group.id
                                }),
                            });
                        });
                        console.log(this.project.tasks);
                    })
                    .catch(function (error) {
                        alert(error);
                    });
                
            },
            openNav() {
                this.$emit("open-nav");
            },
            updatetask(task) {
                if (task.id > 0) {
                    axios.put('http://127.0.0.1:5000/api/Tasks/' + task.id, task)
                        .then(response => {
                            console.log(response);
                        })
                        .catch(error => {
                            console.log(error);
                        });
                }
                else {
                    axios.post('http://127.0.0.1:5000/api/Tasks/', task)
                        .then(response => {
                            console.log(response);
                        })
                        .catch(error => {
                            console.log(error);
                        });
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
            assignuser(task, newuser) {
                task.assignedToUser = newuser;
                this.updatetask(task);
            },
            assigndates(task, startdate, enddate) {
                task.startDate = startdate;
                task.endDate = enddate;
                this.updatetask(task);
            },
            assignpriority(task, priority) {
                task.priority = priority;
                this.updatetask(task);
            },
            assignstatus(task, status) {
                task.status = status;
                this.updatetask(task);
            },
            assignname(task, name, completed) {
                task.name = name;
                task.completed = completed;
                this.updatetask(task);
            },
            showdetailtask(task) {
                this.showDetails = true;
                this.detailtask = task;
            }
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
            this.getRows();
        },
    }
</script>