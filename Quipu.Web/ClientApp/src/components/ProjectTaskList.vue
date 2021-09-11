<template>
    <q-layout>
        <q-page-container>
            <div class="row" style="padding:15px 30px;">
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
                                           @end="drag = false"
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
                                                                   icon="o_check_circle_outline" />
                                                        </div>
                                                        <a>{{ element.name }}</a>
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
                                                    {{ element.assignee }}

                                                </div>
                                                <div class="tablecol datecol">
                                                    {{ element.date }}
                                                </div>
                                                <div class="tablecol prioritycol">
                                                    <q-badge color="orange" rounded>
                                                        {{ element.priority }}
                                                    </q-badge>

                                                </div>

                                                <div class="tablecol statuscol"  @mouseenter="element.statushover = true" 
                                                     @mouseleave="element.statushover = false">
                                                    <q-select :hide-dropdown-icon="!element.statushover"                                                             
                                                              borderless
                                                              v-model="element.status"
                                                              :options="statusoptions"
                                                              dense
                                                              emit-value>

                                                        <template v-slot:option="scope">
                                                            <q-item v-bind="scope.itemProps">
                                                                <q-item-section>
                                                                    <div>
                                                                        <q-icon name="o_check"
                                                                                size="16px"
                                                                                :style="{visibility: scope.opt.category == element.status.id ? 'visible' : 'hidden'}" />
                                                                        <q-badge rounded>
                                                                            {{scope.opt.label}}
                                                                        </q-badge>
                                                                    </div>
                                                                </q-item-section>
                                                            </q-item>
                                                        </template>
                                                        <template v-slot:selected>
                                                            <q-badge rounded>
                                                                {{element.status.name}}
                                                            </q-badge>
                                                        </template>

                                                    </q-select>
                                                </div>
                                            </div>

                                        </div>
                                    </template>

                                    <template #footer>
                                        <div style="margin-top:10px; font-size:14px; border-bottom:0px; margin-left:40px;">
                                            Add task...
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
    .q-field__marginal{
        min-height:0px;
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
</style>

<script>
    import axios from 'axios'
    import draggable from "vuedraggable";

    export default {
        name: "ProjectTaskList",
        components: { draggable },
        props: {
            project: {},
        },
        data() {
            return {
                expanded: true,
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

            }
        },
        methods: {
            getRows() {
                //Get groups
                let taskgroups = [];
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

                axios.get('http://127.0.0.1:5000/api/PriorityTypes')
                    .then((response) => {
                        this.prioritytypes = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });

                axios.get('http://127.0.0.1:5000/api/TaskStatusCategories')
                    .then((response) => {
                        taskgroups = response.data;
                        taskgroups.forEach(group => {
                            this.headerrows.push({
                                name: group.name,
                                expanded: false,
                                priorityhover: false,
                                statushover:true,
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
            hover() {
                console.log("hoverr!");
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
        }
    }
</script>