<template>
    <div class="list-row row" v-if="loaded">
        <q-icon name="o_drag_indicator"
                class="handle"
                @click="task.fixed = !task.fixed"
                style="position:absolute; left:5px"
                size="20px" />
        <div class="list-row-noicon row">
            <div class="tablecol taskcol ">
                <namecell :task="this.task.value"
                          @detailTask="showdetailtask(element)"
                          @updateTask="(name,completed)=>assignname(task,name,completed)" />
            </div>

            <div class="tablecol">
                <assigneecell :userid="task.assignedToUserID"
                              @updateTask="(newuserid) => assignuser(task,newuserid)" />
            </div>

            <div class="tablecol">

                <datecell :startDate="task.startDate" :endDate="task.endDate"
                          @updateTask="(startDate,endDate) => assigndates(task,startDate,endDate)" />

            </div>

            <div class="tablecol">
                <prioritycell :priorityid="task.priorityID"
                              @updateTask="(priority) => assignpriority(task,priority)" />

            </div>

            <div class="tablecol statuscol">
                <statuscell :statusid="task.statusID"
                            @updateTask="(status) => assignstatus(task,status)"/>
            </div>
        </div>

    </div>
</template>

<style scoped>
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

    .list-row {
        min-height: 40px;
        height:40px;
        align-items: center;
        padding: 0px 30px;
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
</style>

<script>
    import assigneecell from "./ProjectTaskList_AssigneeCell"
    import datecell from "./ProjectTaskList_DateCell"
    import prioritycell from "./ProjectTaskList_PriorityCell"
    import statuscell from "./ProjectTaskList_StatusCell"
    import namecell from "./ProjectTaskList_NameCell"
    import { ref,reactive } from 'vue'
    import { useStore } from 'vuex'

    export default {
        name: "ProjectTaskList_Row",
        components: { assigneecell, datecell, prioritycell, statuscell, namecell},
        props: {
            id: Number,
        },
        setup(props) {
            const task = reactive({});
            const loaded = ref(false);
            const store = useStore();
            const detailtask = reactive({});
            const showDetails = ref(false);

            (async () => {
                task.value = await store.getters.getTaskByID(props.id);
                console.log(props.id,task);
                loaded.value = true;
            })();                       
           
            const assignuser = (task, newuserid) => {
                task.assignedToUserID = newuserid;
                updatetask(task);
            };
            const assigndates =(task, startdate, enddate) => {
                task.startDate = startdate;
                task.endDate = enddate;
                updatetask(task);
            };
            const assignpriority = (task, priority) => {
                task.priority = priority;
                updatetask(task);
            };
            const assignstatus =(task, status) => {
                task.status = status;
                updatetask(task);
            };
            const assignname = (task, name, completed) => {
                task.name = name;
                task.completed = completed;
                updatetask(task);
            };
            const showdetailtask = (task) => {
                detailtask.value = null;
                detailtask.value = { ...task };

                showDetails.value = true;
            };

            const updatetask = () => {
                
            };

            return { task, showDetails, loaded, detailtask, updatetask, assignuser, assigndates, assignpriority, assignstatus, assignname, showdetailtask }
        }
    }
</script>