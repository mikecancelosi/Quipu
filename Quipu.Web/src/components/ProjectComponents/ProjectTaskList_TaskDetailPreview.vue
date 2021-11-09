<template>
  <div class="full-height column" id="pagecontainer" v-if="loaded">
    <div id="headercontainer" class="row bg-dark">
      <q-btn
        :label="taskcompleted ? 'Completed' : 'Mark complete'"
        icon="o_done"
        dense
        outline
        v-bind:style="{ color: taskcompleted ? 'green' : 'white' }"
        no-caps
        size="10px;"
        @click="toggleComplete()"
      />
      <q-space />

      <q-btn
        class="actionbtn"
        icon="o_attach_file"
        size="12px"
        dense
        flat
        disable
      />
      <q-btn
        class="actionbtn"
        icon="o_format_list_bulleted"
        size="12px"
        dense
        flat
        disable
      />
      <q-btn
        class="actionbtn"
        icon="o_more_vert"
        size="12px"
        dense
        flat
        @click="refreshComponents()"
      />
      <q-btn
        class="actionbtn"
        icon="mdi-forwardburger"
        size="12px"
        dense
        flat
        @click="hideself()"
      />
    </div>

    <q-separator />
    <q-scroll-area id="contentcontainer">
      <div class="column">
        <div class="headinglabel">{{ task.value.name }}</div>

        <div class="row descriptor">
          <div class="label">Assignee</div>
          <assigneecell
            :userid="task.value.assignedToUserID"
            class="value"
            @updateTask="(newuser) => assignuser(newuser)"
          />
        </div>

        <div class="row descriptor">
          <div class="label">Date</div>
          <datecell
            class="value"
            :startDate="task.value.startDate"
            :endDate="task.value.endDate"
            :key="componentKey"
            @updateTask="
              (startDate, endDate) => assigndates(startDate, endDate)
            "
          />
        </div>

        <div class="row descriptor">
          <div class="label">Dependencies</div>
          <div class="value">Michael Cancelosi</div>
        </div>

        <div class="row descriptor">
          <div class="label">Priority</div>
          <prioritycell
            class="value"
            :priorityid="task.value.priorityID"
            :key="componentKey"
            @updateTask="(priorityid) => assignpriority(priorityid)"
          />
        </div>

        <div class="row descriptor">
          <div class="label">Status</div>
          <statuscell
            class="value"
            :statusid="task.value.statusID"
            :key="componentKey"
            @updateTask="(statusid) => assignstatus(statusid)"
          />
        </div>

        <div class="descriptor">
          <div>Description</div>
          <q-input
            textarea
            autogrow
            outlined
            v-model="description"
            @blur="assigndescription()"
            class="descriptionInput"
          />
        </div>

        <subtasks :taskID="task.value.id" />
        <taskhistory
          v-if="task.value != null"
          :task="task.value"
          :key="componentKey"
        />
      </div>
    </q-scroll-area>

    <discussionreply
      id="replycontainer"
      @updateTask="(discussion) => addDiscussion(discussion)"
    />
  </div>
</template>

<style scoped>
#pagecontainer {
  height: 100%;
  width: 100%;
}

#headercontainer {
  padding: 20px 20px 0px 20px;
  flex: 0 1 auto;
}
#contentcontainer {
  padding: 0px 20px;
  width: 100%;
  flex: 1 1 auto;
}
#replycontainer {
  padding: 10px 20px;
  margin-top: auto;
  max-height: fit-content;
}

.q-separator {
  margin: 20px 0px;
}

.actionbtn {
  margin-left: 10px;
}

.headinglabel {
  font-size: 18px;
  margin-bottom: 20px;
  font-weight: 600;
}

.label {
  width: 150px;
  min-width: 150px;
  color: rgb(255, 255, 255, 0.5);
  font-size: 12px;
}
.row {
  width: 100%;
  flex-wrap: nowrap;
}

.descriptor {
  align-items: center;
  margin-bottom: 10px;
  min-height: 40px;
}

.value {
  max-width: 150px;
  min-height: 40px;
}

.descriptionInput {
  width: 100%;
  margin-bottom: 10px;
}
</style>

<script>
import assigneecell from "./ProjectTaskList_AssigneeCell";
import datecell from "./ProjectTaskList_DateCell";
import prioritycell from "./ProjectTaskList_PriorityCell";
import statuscell from "./ProjectTaskList_StatusCell";
import subtasks from "./ProjectTaskList_Subtasks";
import discussionreply from "./ProjectTaskList_TaskDiscussionReply";
import taskhistory from "./ProjectTaskList_TaskHistory";
import { reactive, ref, computed } from "vue";
import { useStore } from "vuex";

export default {
  name: "TaskDetailPreview",
  components: {
    assigneecell,
    datecell,
    prioritycell,
    statuscell,
    subtasks,
    discussionreply,
    taskhistory,
  },
  emits: ["update-task", "hide-details", "task-updated"],
  props: {
    id: Number,
  },
  setup(props, { emit }) {
    const hover = ref(false);
    const componentKey = ref(0);
    const store = useStore();
    const task = reactive({});
    const loaded = ref(false);
    const description = ref("");

    (async () => {
      task.value = await store.getters.getTaskByID(props.id);
      description.value = task.value.description;
      loaded.value = true;
    })();

    const hideself = () => {
      emit("hide-details");
    };
    const refreshComponents = () => {
      componentKey.value += 1;
    };

    const addDiscussion = async (discussion) => {
      var newDiscussion = {
        date_Posted: new Date().toISOString().slice(0, 19).replace("T", " "),
        message_Contents: discussion,
        owner: task.value.discussionOwner,
        ownerID: task.value.discussionOwnerID,
        userID: 12,
      };
      await store.dispatch("postDiscussion", newDiscussion);
      await store.dispatch("fetchTasks");
      refreshTask();
    };

    const assignuser = async (newuserid) => {
      task.value.assignedToUser = await store.getters.getUserByID(newuserid);
      task.value.assignedToUserID = newuserid;
      updatetask();
    };
    const assigndates = (startdate, enddate) => {
      task.value.startDate = startdate;
      task.value.endDate = enddate;
      updatetask();
    };
    const assignpriority = async (priorityid) => {
      task.value.priority = await store.getters.getPriorityByID(priorityid);
      task.value.priorityID = priorityid;
      updatetask();
    };
    const assignstatus = async (statusid) => {
      task.value.status = await store.getters.getStatusByID(statusid);
      task.value.statusID = statusid;
      updatetask();
    };
    const assignname = (name, completed) => {
      task.value.name = name;
      task.value.completed = completed;
      updatetask();
    };
    const assigndescription = () => {
      task.value.description = description.value;
      updatetask();
    };

    const updatetask = () => {
      store.dispatch("updateTask", task.value);
      emit("task-updated");
    };

    const refreshTask = async () => {
      task.value = await store.getters.getTaskByID(props.id);
      refreshComponents();
    };

    //Completed btn
    const toggleComplete = () => {
      task.value.completed = !task.value.completed;
      updatetask();
    };

    const taskcompleted = computed(() => {
      return task?.value.completed ?? false;
    });

    return {
      hover,
      componentKey,
      updatetask,
      hideself,
      refreshComponents,
      addDiscussion,
      task,
      loaded,
      refreshTask,
      assignname,
      assignstatus,
      assignuser,
      assigndates,
      assignpriority,
      description,
      assigndescription,
      taskcompleted,
      toggleComplete,
    };
  },
};
</script>
