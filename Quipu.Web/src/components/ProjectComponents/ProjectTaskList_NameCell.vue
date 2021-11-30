<template>
  <div class="cell">
    <div class="row">
      <div>
        <q-btn
          dense
          round
          flat
          v-bind:style="{ color: completed ? 'green' : 'white' }"
          @click="
            completed = !completed;
            updatetask();
          "
          class="checkbox"
          icon="check_circle_outline"
        />
      </div>
      <div id="inputContainer">
        <q-input
          ref="nameinput"
          debounce="1000"
          dense
          borderless
          data-cy="input"
          v-model="name"
          @update:model-value="(val) => focusChange(true)"
          @blur="(evt) => focusChange(false)"
        />
      </div>
      <q-space />
      <q-btn
        label="Details"
        icon-right="chevron_right"
        flat
        dense
        no-caps
        class="showonhover"
        :ripple="false"
        id="detailsbtn"
        @click="this.detailtask()"
      />
    </div>
  </div>
</template>

<style>
.cell {
  width: 100%;
  height: 100%;
}
.checkbox:hover {
  color: green;
}

.cell .showonhover {
  visibility: hidden;
}

.cell:hover .showonhover {
  visibility: visible;
}
/* quickfix for inputs cutting off */
#inputContainer {
  width: 500px;
}
</style>

<script>
import { onMounted, ref, nextTick } from "vue";

export default {
  name: "NameCell",
  emits: ["update-task", "detail-task", "remove-task"],
  props: {
    task: {},
  },
  setup(props, { emit }) {
    const showdropdown = ref(false);
    const name = ref(props.task.name);
    const completed = ref(props.task.completed);
    const updatetask = () => {
      emit("update-task", name, completed);
    };
    const nameinput = ref(null);

    const focusChange = (focus) => {
      if (!focus) {
        if (name.value === "") {
          emit("remove-task", props.task);
        } else {
          updatetask();
        }
      } else {
        //  root.$nextTick(() => { this.$refs['nameinput'].focus(); });
      }
    };

    onMounted(async () => {
      if (name.value == "") {
        await nextTick();
        nameinput.value.focus();
      }
    });

    const detailtask = () => {
      emit("detail-task");
    };

    return {
      showdropdown,
      name,
      completed,
      updatetask,
      focusChange,
      detailtask,
      nameinput,
    };
  },
};
</script>
