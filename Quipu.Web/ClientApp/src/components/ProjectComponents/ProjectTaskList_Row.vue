<template>
    <div class="list-row row" v-if="loaded">
        <q-icon name="o_drag_indicator"
                class="handle"
                @click="task.fixed = !task.fixed"
                style="position:absolute; left:5px"
                size="20px" />
        <div class="list-row-noicon row">
            <div class="tablecol taskcol ">
                <namecell :task="this.task"
                          @detailTask="showdetailtask(element)"
                          @updateTask="(name,completed)=>assignname(task,name,completed)" />
            </div>

            <div class="tablecol">
                <assigneecell :userid="task.value.assignedToUserID"
                              @updateTask="(newuser) => assignuser(task,newuser)" />
            </div>

            <div class="tablecol">

                <datecell :startDate="task.value.startDate" :endDate="task.value.endDate"
                          @updateTask="(startDate,endDate) => assigndates(task,startDate,endDate)" />

            </div>

            <div class="tablecol">
                <prioritycell :priorityid="task.value.priorityID"
                              @updateTask="(priority) => assignpriority(task,priority)" />

            </div>

            <div class="tablecol statuscol">
                <statuscell :statusid="task.value.statusID"
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
    import { RepositoryFactory } from '../../repositories/RepositoryFactory'
    const TaskRepo = RepositoryFactory.get('tasks')

    export default {
        name: "ProjectTaskList_Row",
        components: { assigneecell, datecell, prioritycell, statuscell, namecell},
        props: {
            id: Number,
        },
        setup(props) {
            const task = reactive({});
            const loaded = ref(false);

            (async () => {
                const res = await TaskRepo.getTask(props.id);            
                task.value = res.data;
                loaded.value = true;
            })();
                       
           
            const assignuser = (task, newuser) => {
                task.assignedToUser = newuser;
                this.updatetask(task);
            };
            const assigndates =(task, startdate, enddate) => {
                task.startDate = startdate;
                task.endDate = enddate;
                this.updatetask(task);
            };
            const assignpriority = (task, priority) => {
                task.priority = priority;
                this.updatetask(task);
            };
            const assignstatus =(task, status) => {
                task.status = status;
                this.updatetask(task);
            };
            const assignname = (task, name, completed) => {
                task.name = name;
                task.completed = completed;
                this.updatetask(task);
            };
            const showdetailtask = (task) => {
                this.detailtask = null;
                this.detailtask = { ...task };

                this.showDetails = true;
            };

            return { task,loaded, assignuser, assigndates, assignpriority, assignstatus, assignname, showdetailtask }
        }
    }
</script>