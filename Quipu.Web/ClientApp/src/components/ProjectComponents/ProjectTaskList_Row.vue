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
                <assigneecell :userid="task.value.assignedToUserID"
                              @updateTask="(newuserid) => assignuser(task,newuserid)" />
            </div>

            <div class="tablecol">

                <datecell :startDate="task.value.startDate" :endDate="task.value.endDate"
                          @updateTask="(startDate,endDate) => assigndates(task,startDate,endDate)" />

            </div>

            <div class="tablecol">
                <prioritycell :priorityid="task.value.priorityID"
                              @updateTask="(priorityid) => assignpriority(task,priorityid)" />

            </div>

            <div class="tablecol statuscol">
                <statuscell :statusid="task.value.statusID"
                            @updateTask="(statusid) => assignstatus(task,statusid)"/>
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
                loaded.value = true;
            })();

            const assignuser = (task, newuserid) => {
                task.value.assignedToUserID = newuserid;
                updatetask();
            };
            const assigndates =(task, startdate, enddate) => {
                task.value.startDate = startdate;
                task.value.endDate = enddate;
                updatetask();
            };
            const assignpriority = (task, priorityid) => {
                task.value.priorityID = priorityid;
                updatetask();
            };
            const assignstatus =(task, statusid) => {
                task.value.statusID = statusid;
                updatetask();
            };
            const assignname = (task, name, completed) => {
                task.value.name = name;
                task.value.completed = completed;
                updatetask();
            };
            const showdetailtask = (task) => {
                detailtask.value = null;
                detailtask.value = { ...task };

                showDetails.value = true;
            };

            const updatetask = () => {
                store.dispatch('updateTask', task.value)
            };

            return { task, showDetails, loaded, detailtask, updatetask, assignuser, assigndates, assignpriority, assignstatus, assignname, showdetailtask }
        }
    }
</script>