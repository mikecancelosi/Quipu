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
                <q-btn class="actionbtn" icon="o_more_vert" size="12px" dense flat disable />
                <q-btn class="actionbtn" icon="mdi-forwardburger"
                                         size="12px" 
                                         dense
                                         flat 
                                         @click="hideself()" />
            </div>
            <q-separator />

            <div class="headinglabel">{{task?.name ?? ""}}</div>

            <div class="row">
                <div class="label">Assignee</div>
                <assigneecell :task="task"
                              @updateTask="(newuser) => assignuser(element,newuser)"/>
            </div>

            <div class="row">
                <div class="label">Date</div>
                <datecell :task="task"/>
            </div>

            <div class="row">
                <div class="label">Project</div>
                <div class="value">Michael Cancelosi</div>
            </div>

            <div class="row">
                <div class="label">Dependencies</div>
                <div class="value">Michael Cancelosi</div>
            </div>

            <div class="row">
                <div class="label">Priority</div>
                <div class="value">{{task?.priority?.name}}</div>
            </div>

            <div class="row">
                <div class="label">Status</div>
                <div class="value">{{task?.status?.name}}</div>
            </div>

            <div class="row">
                <div class="label">Description</div>
                <div class="value" style="width:100%; float:left;">
                    <q-input textarea
                             outlined
                             v-model="description"/>
                </div>
            </div>

            <q-space/>
            <q-separator/>

            <div class="reply">
                
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
        margin-bottom:20px;
    }
    .row{
        width:100%;
        flex-wrap:nowrap;
    }

    .reply{
        max-height:300px;
        min-height:100px;
        background: rgb(0,0,0,.2);
    }

    .value {
    }
</style>

<script>
    import assigneecell from "./ProjectTaskList_AssigneeCell"
    import datecell from "./ProjectTaskList_DateCell"

    export default {
        name: "TaskDetailPreview",
        components: { assigneecell, datecell},
        emits: ["update-task","hide-details"],
        props: {
            task: {},
        },
        data() {
            return {
                hover: false,
                description: "",
            }
        },
        methods: {
            updatetask() {
                this.$emit("update-task", this.newstartdate, this.newenddate);
            },
            hideself() {
                this.$emit("hide-details");
                console.log("emit?");
            }

        },

    }
</script>