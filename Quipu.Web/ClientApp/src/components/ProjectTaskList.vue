<template>
    <q-layout>
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

                                                    <div class="row">
                                                        <div>
                                                            <q-btn dense
                                                                   round
                                                                   flat
                                                                   v-bind:style="{color: element.completed ? 'green'
                                                                                                           : 'white'}"
                                                                   @click="element.completed = !element.completed; updatetask(element);"
                                                                   class="checkbox"
                                                                   icon="o_check_circle_outline" />
                                                        </div>
                                                        <q-input ref="nameinput"
                                                                 debounce="1000"
                                                                 dense
                                                                 borderless
                                                                 v-model="element.name"
                                                                 @update:model-value="(val)=>tasklostfocus(element,true)"
                                                                 @blur="(evt)=>tasklostfocus(element)" />
                                                        <q-space />
                                                        <q-btn label="Details"
                                                               icon-right="o_chevron_right"
                                                               flat
                                                               dense
                                                               no-caps
                                                               class="showonhover" />
                                                    </div>
                                                </div>

                                                <div class="tablecol assigncol">
                                                   <assigneecell :task="element" 
                                                                 :users="users"
                                                                 :useroptions="useroptions"
                                                                 @updateTask="(newuser) => assignuser(element,newuser)"/>
                                                </div>

                                                <div class="tablecol datecol">
                                                    
                                                   <datecell :task="element" 
                                                             @updateTask="(startDate,endDate) => assigndates(element,startDate,endDate)"/>

                                                </div>

                                                <div class="tablecol prioritycol">
                                                    <prioritycell :task="element"
                                                                  :priorityoptions=" this.priorityoptions"
                                                                  @updateTask="(priority) => assignpriority(element,priority)"/>

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

        .list-row-noicon .tablecol .showonhover {
            visibility: hidden;
        }

        .list-row-noicon .tablecol:hover .showonhover {
            visibility: visible;
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

    .q-input {
        padding: 5px;
        min-height: 0px;
        max-height: 30px;
        align-content: center;
        margin: 5px;
    }

        .q-input:hover {
            background-color: rgb(0,0,0,.3);
            outline: 1px solid rgb(255,255,255,.4);
            height: fit-content;
        }

    .q-field--focused {
        background-color: rgb(0,0,0,.3);
        outline: 1px solid rgb(255,255,255,.4);
        height: fit-content;
    }

    .checkbox:hover{
        color:green;
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
    
</style>

<script>
    import axios from 'axios'
    import draggable from "vuedraggable";
    import assigneecell from "./ProjectComponents/ProjectTaskList_AssigneeCell"
    import datecell from "./ProjectComponents/ProjectTaskList_DateCell"
    import prioritycell from "./ProjectComponents/ProjectTaskList_PriorityCell"
    import statuscell from "./ProjectComponents/ProjectTaskList_StatusCell"

    export default {
        name: "ProjectTaskList",
        components: { draggable, assigneecell, datecell, prioritycell, statuscell },
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
                users: [],
                useroptions: [],
                taskstatusgroups:[],
            }
        },
        methods: {
            getPriorityTypes() {
                axios.get('http://127.0.0.1:5000/api/PriorityTypes')
                    .then((response) => {
                        this.prioritytypes = response.data;
                        this.prioritytypes.forEach(priority => {
                            this.priorityoptions.push({
                                label: priority.name,
                                value: priority,
                                category: priority.id,
                            });
                        });
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            getStatusTypes() {
                axios.get('http://127.0.0.1:5000/api/StatusTypes')
                    .then((response) => {
                        this.statustypes = response.data;
                        this.statustypes.forEach(status => {
                            this.statusoptions.push({
                                label: status.name,
                                value: status,
                                category: status.id,
                            });
                        });
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            getUsers() {
                axios.get('http://127.0.0.1:5000/api/Users')
                    .then((response) => {
                        this.users = response.data;
                        this.users.forEach(user => {
                            this.useroptions.push({
                                label: user.display_Name,
                                value: user,
                                category: user.id,
                            });
                        });
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
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
            tasklostfocus(task, focus) {
                if (task.name === '') {
                    this.getRows();
                } else {
                    this.updatetask(task);
                }
                if (focus) {
                    this.$nextTick(() => { this.$refs['nameinput'].focus(); });
                }
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
            this.getPriorityTypes();
            this.getUsers();
            this.getStatusTypes();
            this.getRows();
        },
    }
</script>