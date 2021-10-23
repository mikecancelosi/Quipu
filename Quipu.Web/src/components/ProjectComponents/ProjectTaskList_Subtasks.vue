<template>
  <div id="subtasks-container">
    <div v-if="hasSubTasks">
      <div class="label">Subtasks</div>

      <div
        class="row taskcontainer"
        v-for="(task, i) in mutSubTasks"
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
          @click="task.completed = !task.completed"
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
      @click="this.addTask()"
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

export default {
  name: "Subtasks",
  props: {
    taskID: {
      type: Number,
      default: 0,
    },
    subtasks: {
      type: Array,
      default: () => [],
    },
  },
  setup(props) {
    const taskDivs = ref([]);
    const mutSubTasks = ref(props.subtasks);
    const hasSubTasks = computed(() => mutSubTasks.value.length > 0);

    const addTask = async () => {
      mutSubTasks.value.push({
        name: "",
        completed: false,
      });

      await nextTick();

      const lastElement = taskDivs.value.at(-1);
      const inputElement = lastElement.children[1];
      inputElement.focus();
    };

    const onTaskLostFocus = (task) => {
      if (task.name === "") {
        const index = mutSubTasks.value.indexOf(task);
        mutSubTasks.value.splice(index, 1);
      } else {
        pushToDB();
      }
    };

    const clearEmptyTasks = () => {
      mutSubTasks.value = mutSubTasks.value.filter(
        (task) => task.name.length > 0
      );
    };

    const pushToDB = () => {};

    return {
      hasSubTasks,
      mutSubTasks,
      addTask,
      clearEmptyTasks,
      taskDivs,
      onTaskLostFocus,
      pushToDB,
    };
  },
};
</script>
