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
                                  class="value"
                                  @updateTask="(newuser) => assignuser(element,newuser)" />
                </div>

                <div class="row descriptor">
                    <div class="label">Date</div>
                    <datecell class="value" :startDate="this.task.startDate" :endDate="this.task.endDate" :key="componentKey" />
                </div>

                <div class="row descriptor">
                    <div class="label">Dependencies</div>
                    <div class="value">Michael Cancelosi</div>
                </div>

                <div class="row descriptor">
                    <div class="label">Priority</div>
                    <prioritycell class="value" :priority="this.task.priority"  :key="componentKey" />
                </div>

                <div class="row descriptor">
                    <div class="label">Status</div>
                    <statuscell class="value" :status="this.task.status"  :key="componentKey" />
                </div>

                <div class="descriptor">
                    <div >Description</div>
                        <q-input textarea
                                 autogrow
                                 outlined
                                 v-model="this.description" 
                                 class="descriptionInput"/>
                </div>

                <subtasks />
                

                <div class="reply fixed-bottom row">
                    <div class="col-1">
                        <q-avatar
                                  color="red"
                                  text-color="white"
                                  size="35px">M</q-avatar>
                    </div>
                    <div class="col-11">
                        <div class="column">
                            <div class="col">
                                <q-input outlined dense placeholder="Ask a question or post an update..." />
                            </div>
                            <div class="reply-footer row float-right">
                                <a style="margin-right:20px; font-size:12px; color:rgb(255,255,255,.3)">Collaborators</a>

                                <div id="collab-section">
                                    <q-avatar class="contributorIcons" color="yellow" text-color="black" size="24px">MC</q-avatar>
                                    <q-avatar class="contributorIcons" color="yellow" text-color="black" size="24px">ED</q-avatar>
                                    <q-avatar class="contributorIcons" color="yellow" text-color="black" size="24px">D</q-avatar>
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

    .value{
        max-width:150px;
    }

    .reply {
        padding: 5px 20px;
    }
    .reply-footer{
        min-height:40px;
        margin-top:15px;
        align-items:center;
    }

    .contributorIcons{
        margin-right:4px;
    }

    .descriptionInput {
        width:100%; 
        margin-bottom:10px;
    }

</style>

<script>
    import assigneecell from "./ProjectTaskList_AssigneeCell"
    import datecell from "./ProjectTaskList_DateCell"
    import prioritycell from "./ProjectTaskList_PriorityCell"
    import statuscell from "./ProjectTaskList_StatusCell"
    import subtasks from "./ProjectTaskList_Subtasks"
    import {reactive } from 'vue'

    export default {
        name: "TaskDetailPreview",
        components: { assigneecell, datecell, prioritycell, statuscell, subtasks},
        emits: ["update-task", "hide-details"],
        props: {
            task: reactive({}),
        },
        data() {
            return {
                hover: false,
                description: this.task.description,
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
        updated() {
            this.description = this.task.description;
        }

    }
</script>