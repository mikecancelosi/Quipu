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
                                                                 :users="this.users"
                                                                 :useroptions="this.useroptions"
                                                                 @updateTask="(newuser) => assignuser(element,newuser)"/>
                                                </div>

                                                <div class="tablecol datecol"
                                                     @mouseenter="element.datehover = true"
                                                     @mouseleave="element.datehover = false">

                                                    <q-btn icon="o_calendar_today"
                                                           round
                                                           flat
                                                           outline
                                                           dense
                                                           size="10px"
                                                           v-if="element.datehover &&
                                                                 !element.datedropdown &&
                                                                 element.startDate == '0001-01-01T00:00:00'"
                                                           @click=" element.datedropdown = true; "
                                                           :style="{
                                                                    visibility: element.startDate == '0001-01-01T00:00:00'
                                                                                                     ? 'visible'
                                                                                                     : 'collapse'}">

                                                    </q-btn>

                                                    <div class="row" v-if="element.startDate != '0001-01-01T00:00:00'">
                                                        <div>
                                                            {{formatdate(element.startDate,element.endDate)}}
                                                        </div>
                                                        <q-space />
                                                        <q-btn dense
                                                               round
                                                               flat
                                                               icon="o_close"
                                                               v-if="element.datehover"
                                                               size="12px"
                                                               style="margin:5px;"
                                                               @click="cleardates(element);" />
                                                    </div>
                                                    <q-menu v-bind:model-value="element.datedropdown"
                                                            v-bind:no-parent-event="true"
                                                            @hide="element.datedropdown=false">
                                                        <q-date range
                                                                v-model="element.dates"
                                                                @range-end="(range)=>assigndate(range,element)" />
                                                    </q-menu>

                                                </div>

                                                <div class="tablecol prioritycol"
                                                     @mouseenter="element.priorityhover = true"
                                                     @mouseleave="element.priorityhover = false">
                                                    <q-select :hide-dropdown-icon="!element.priorityhover"
                                                              borderless
                                                              v-model="element.priority"
                                                              @update:model-value="updatetask(element)"
                                                              :options="priorityoptions"
                                                              dense
                                                              emit-value>

                                                        <template v-slot:option="scope">
                                                            <q-item v-bind="scope.itemProps">
                                                                <q-item-section>
                                                                    <div>
                                                                        <q-icon name="o_check"
                                                                                size="16px"
                                                                                :style="{visibility: scope.opt.category == (element.priority?.id ?? 0)
                                                                                                                        ? 'visible'
                                                                                                                        : 'hidden'}" />
                                                                        <q-badge rounded :color="scope.opt.value.color">
                                                                            {{scope.opt.label}}
                                                                        </q-badge>
                                                                    </div>
                                                                </q-item-section>
                                                            </q-item>
                                                        </template>
                                                        <template v-slot:selected>
                                                            <q-badge rounded
                                                                     :color="element.priority?.color ?? 'primary'"
                                                                     v-if="element.priority != null">
                                                                {{element.priority?.name ?? ''}}
                                                            </q-badge>
                                                        </template>

                                                    </q-select>

                                                </div>

                                                <div class="tablecol statuscol"
                                                     @mouseenter="element.statushover = true"
                                                     @mouseleave="element.statushover = false">
                                                    <q-select :hide-dropdown-icon="!element.statushover"
                                                              borderless
                                                              v-model="element.status"
                                                              @update:model-value="updatetask(element)"
                                                              :options="statusoptions"
                                                              dense
                                                              emit-value>

                                                        <template v-slot:option="scope">
                                                            <q-item v-bind="scope.itemProps">
                                                                <q-item-section>
                                                                    <div>
                                                                        <q-icon name="o_check"
                                                                                size="16px"
                                                                                :style="{visibility: scope.opt.category == (element.status?.id ?? 0)
                                                                                                                        ? 'visible'
                                                                                                                        : 'hidden'}" />
                                                                        <q-badge rounded :color="scope.opt.value.color">
                                                                            {{scope.opt.label}}
                                                                        </q-badge>
                                                                    </div>
                                                                </q-item-section>
                                                            </q-item>
                                                        </template>
                                                        <template v-slot:selected>
                                                            <q-badge rounded
                                                                     :color="element.status?.color ?? 'primary'"
                                                                     v-if="element.status != null">
                                                                {{element.status?.name ?? ''}}
                                                            </q-badge>
                                                        </template>

                                                    </q-select>
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
    
</style>

<script>
    import axios from 'axios'
    import draggable from "vuedraggable";
    import { assigneecell} from "./ProjectComponents/ProjectTaskList_AssigneeCell"

    export default {
        name: "ProjectTaskList",
        components: { draggable, assigneecell },
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
                prioritytypes: [],
                headerrows: [],
                drag: false,
                statusoptions: [],
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
            navigateToProject(evt, row) {
                this.$router.push('/Projects/' + row.id);
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
            formatdate(startDate, endDate) {
                var sDate = new Date(startDate);
                var eDate = new Date(endDate);
                return sDate.getMonth() + "/" + sDate.getDate() + "-" +
                    eDate.getMonth() + "/" + eDate.getDate();
            },
            assigndate(range, task) {
                task.startDate = new Date(range.from.month + " " + range.from.day + " " + range.from.year);
                task.endDate = new Date(range.to.month + " " + range.to.day + " " + range.to.year);
                axios.put('http://127.0.0.1:5000/api/Tasks/' + task.id, task)
                    .then(response => {
                        console.log(response);
                    })
                    .catch(error => {
                        console.log(error);
                    });
            },
            cleardates(task) {
                task.startDate = '0001-01-01T00:00:00';
                task.endDate = '0001-01-01T00:00:00';
                task.dates = {};
                this.updatetask(task);
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
        beforeCreate() {
            this.$options.components.assigneecell = require('./ProjectComponents/ProjectTaskList_AssigneeCell.vue').default;
        },
    }
</script>