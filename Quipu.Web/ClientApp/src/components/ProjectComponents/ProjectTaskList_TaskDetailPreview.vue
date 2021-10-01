<template>
    <q-page-container>
        <div id="previewcontainer">
            <div class="row">
                <q-btn label="Mark complete"
                       icon="o_done"
                       dense
                       outline
                       no-caps
                       size="10px;" />
                <q-space />

                <q-btn class="actionbtn" icon="o_attach_file" size="12px" dense flat disable />
                <q-btn class="actionbtn" icon="o_format_list_bulleted" size="12px" dense flat disable />
                <q-btn class="actionbtn" icon="o_more_vert" size="12px" dense flat @click="refreshComponents()"/>
                <q-btn class="actionbtn" icon="mdi-forwardburger" 
                                         size="12px" 
                                         dense
                                         flat 
                                         @click="hideself()" />
            </div>
            <q-separator />

            <div class="headinglabel">{{task?.name ?? ""}}</div>
            
                <div class="row descriptor">
                    <div class="label">Assignee</div>
                    <assigneecell :user="this.task.assignedToUser"
                                  @updateTask="(newuser) => assignuser(element,newuser)" />
                </div>

                <div class="row descriptor">
                    <div class="label">Date</div>
                    <datecell :startDate="this.task.startDate" :endDate="this.task.endDate" :key="componentKey" />
                </div>

                <div class="row descriptor">
                    <div class="label">Project</div>
                    <div class="value">Michael Cancelosi</div>
                </div>

                <div class="row descriptor">
                    <div class="label">Dependencies</div>
                    <div class="value">Michael Cancelosi</div>
                </div>

                <div class="row descriptor">
                    <div class="label">Priority</div>
                    <prioritycell :priority="this.task.priority" style="max-width:150px;" :key="componentKey" />
                </div>

                <div class="row descriptor">
                    <div class="label">Status</div>
                    <statuscell :status="this.task.status" style="max-width:150px;" :key="componentKey" />
                </div>

                <div class="row ">
                    <div class="label">Description</div>
                    <div class="value" style="width:100%; float:left;">
                        <q-input textarea
                                 outlined
                                 v-model="description" />
                    </div>
                </div>

                <div id="subtasks-container">
                    <div class="label">Subtasks</div>

                </div>

                <q-space />
                <q-separator />

                <div class="reply fixed-bottom row">
                    <div class="col-1">
                        <q-avatar color="red" text-color="white" size="35px">M</q-avatar>
                    </div>
                    <div class="col-11">
                        <div class="column">
                            <div class="col">
                                <q-input outlined dense placeholder="Ask a question or post an update..." />
                            </div>
                            <div class="reply-footer row float-right">
                                <a style="margin-right:20px; font-size:12px; color:rgb(255,255,255,.3)">Collaborators</a>

                                <div id="collab-section">
                                    <q-avatar color="yellow" text-color="black" size="24px">MC</q-avatar>
                                    <q-avatar color="yellow" text-color="black" size="24px">ED</q-avatar>
                                    <q-avatar color="yellow" text-color="black" size="24px">D</q-avatar>
                                </div>
                                <q-btn icon="o_add" disable flat rounded dense />

                                <q-space />
                                <q-btn icon="o_notifications" dense no-caps flat label="Leave task" />

                            </div>
                        </div>
                    </div>
                </div>
        </div>
    </q-page-container>
</template>

<style scoped>

    #previewcontainer{
        padding:20px;
    }

    .q-separator{
        margin:20px 0px;
    }

    .actionbtn{
        margin-left:10px;
    }

    .headinglabel{
        font-size: 18px;
        margin-bottom: 20px;
        font-weight:600;
    }

    .label{
        width:150px;
        min-width:150px;
        color:rgb(255,255,255,.5);
        font-size:12px;
       
    }
    .row{
        width:100%;
        flex-wrap:nowrap;       
    }

    .descriptor {
        align-items: center;
        margin-bottom: 10px;
    }

    .reply {
        padding: 5px 20px;
    }
    .reply-footer{
        min-height:40px;
        margin-top:15px;
        align-items:center;
    }

    .q-avatar{
        margin-right:4px;
    }

</style>

<script>
    import assigneecell from "./ProjectTaskList_AssigneeCell"
    import datecell from "./ProjectTaskList_DateCell"
    import prioritycell from "./ProjectTaskList_PriorityCell"
    import statuscell from "./ProjectTaskList_StatusCell"
    import {reactive } from 'vue'

    export default {
        name: "TaskDetailPreview",
        components: { assigneecell, datecell, prioritycell, statuscell},
        emits: ["update-task", "hide-details"],
        computed:{
            gettask() { return this.task;}
        },
        props: {
            task: reactive({}),
        },
        data() {
            return {
                hover: false,
                description: "",
                componentKey: 0,
            }
        },
        methods: {
            updatetask() {
                this.$emit("update-task", this.newstartdate, this.newenddate);
            },
            hideself() {
                this.$emit("hide-details");
            },
            refreshComponents() {
                this.$forceUpdate();
                this.componentKey += 1;
            }
        },

    }
</script>