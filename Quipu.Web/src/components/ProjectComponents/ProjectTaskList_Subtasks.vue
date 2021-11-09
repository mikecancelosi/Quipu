<template>
  <div id="subtasks-container">
    <div v-if="hasSubTasks">
      <div class="label">Subtasks</div>

      <div
        class="row taskcontainer"
        v-for="(task, i) in parentTask.subtasks"
        :key="task"
        :ref="
          (el) => {
            taskDivs[i] = el;
          }
        "
      >
        <q-btn
          dense
          round
          flat
          v-bind:style="{ color: task.completed ? 'green' : 'white' }"
          @click="toggleTaskCompletion(task)"
          class="checkbox"
          size="12px"
          icon="o_check_circle_outline"
        />

        <q-input
          v-model="task.name"
          borderless
          dense
          placeholder="Task name"
          @blur="onTaskLostFocus(task)"
          ref="nameinput"
        />
      </div>
    </div>

    <q-btn
      label="Add subtask"
      icon="o_add"
      dense
      outline
      no-caps
      id="addTask"
      @click="addTask()"
    />
  </div>
</template>

<style scoped>
#subtasks-container {
  margin-top: 10px;
}

.label {
  color: rgb(255, 255, 255, 0.5);
  font-size: 12px;
}

.taskcontainer {
  border: 1px solid rgb(255, 255, 255, 0.4);
  border-left: 0px;
  border-right: 0px;
}

#addTask {
  margin-top: 10px;
  font-size: 12px;
  padding: 5px;
  border-radius: 8px;
}

#addTask::before {
  border-color: rgb(255, 255, 255, 0.5);
}
</style>

<script>
import { computed, ref, nextTick } from "vue";
import { useStore } from "vuex";

export default {
  name: "Subtasks",
  props: {
    taskID: {
      type: Number,
      default: 0,
    },
  },
  setup(props) {
    const taskDivs = ref([]);
    const parentTask = ref({});
    const store = useStore();

    (async () => {
      parentTask.value = await store.getters.getTaskByID(props.taskID);
      console.log(parentTask.value);
    })();
    const subtasks = computed(() => parentTask?.value?.subtasks ?? []);
    const hasSubTasks = computed(() => (subtasks?.value?.length ?? 0) > 0);

    const addTask = async () => {
      subtasks.value.push({
        name: "",
        completed: false,
        parentTaskID: props.taskID,
        projectID: parentTask.value.projectID,
      });

      await nextTick();

      const lastElement = taskDivs.value.at(-1);
      const inputElement = lastElement.children[1];
      inputElement.focus();
    };

    const onTaskLostFocus = (task) => {
      if (task.name === "") {
        const index = subtasks.value.indexOf(task);
        subtasks.value.splice(index, 1);
      } else {
        pushToDB(task);
      }
    };

    const clearEmptyTasks = () => {
      subtasks.value = subtasks.value.filter((task) => task.name.length > 0);
    };

    const toggleTaskCompletion = (task) => {
      task.completed = !task.completed;
      pushToDB(task);
    };

    const pushToDB = (task) => {
      store.dispatch("updateTask", task);
    };

    return {
      hasSubTasks,
      addTask,
      clearEmptyTasks,
      taskDivs,
      onTaskLostFocus,
      pushToDB,
      parentTask,
      store,
      subtasks,
      toggleTaskCompletion,
    };
  },
};
</script>
