<template>
    <q-page-container>
        <div id="previewcontainer" >
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

            <div class="headinglabel">{{task.value.name}}</div>
            
                <div class="row descriptor">
                    <div class="label">Assignee</div>
                    <assigneecell :userid="task.value.assignedToUserID"
                                  class="value"
                                  @updateTask="(newuser) => assignuser(element,newuser)" />
                </div>

                <div class="row descriptor">
                    <div class="label">Date</div>
                    <datecell class="value" 
                              :startDate="task.value.startDate" 
                              :endDate="task.value.endDate"
                              :key="componentKey" />
                </div>

                <div class="row descriptor">
                    <div class="label">Dependencies</div>
                    <div class="value">Michael Cancelosi</div>
                </div>

                <div class="row descriptor">
                    <div class="label">Priority</div>
                    <prioritycell class="value" :priorityid="task.value.priorityID"  :key="componentKey" />
                </div>

                <div class="row descriptor">
                    <div class="label">Status</div>
                    <statuscell class="value" :statusid="task.value.statusID"  :key="componentKey" />
                </div>

                <div class="descriptor">
                    <div>Description</div>
                        <q-input textarea
                                 autogrow
                                 outlined
                                 v-model="description.value" 
                                 class="descriptionInput"/>
                </div>

                <subtasks />
                <taskhistory :task="task"/>
                

                <div class="fixed-bottom">
                   <discussionreply/>
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
    import discussionreply from "./ProjectTaskList_TaskDiscussionReply"
    import taskhistory from "./ProjectTaskList_TaskHistory"
    import {reactive,ref } from 'vue'

    export default {
        name: "TaskDetailPreview",
        components: {
            assigneecell, datecell, prioritycell, statuscell,
            subtasks, discussionreply, taskhistory,
        },
        emits: ["update-task", "hide-details"],
        props: {
            task: reactive({}),
        },
        setup(props, { emit }) {
            const hover = ref(false);
            const description = ref("");
            const componentKey = ref(0);

            description.value = ref(props.task.value.description);
            const updatetask=()=> {
                
            };
            const hideself = () =>{
                emit("hide-details");
            };
            const refreshComponents = () =>{
                //this.$forceUpdate();
                componentKey.value += 1;
            };

            return {
                hover, description, componentKey, updatetask,
                hideself, refreshComponents
            }
        },
        updated() {
            this.description = this.task.description;
        }

    }
</script>