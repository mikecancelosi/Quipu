<template>
  <div class="cell" @mouseenter="hover = true" @mouseleave="hover = false">
    <q-btn
      icon="o_calendar_today"
      round
      flat
      outline
      dense
      size="10px"
      v-if="hover && !showdropdown && dateModel.from === '0001-01-01T00:00:00'"
      @click="showdropdown = true"
      :style="{
        visibility:
          dateModel.from == '0001-01-01T00:00:00' ? 'visible' : 'collapse',
      }"
    >
    </q-btn>
    <div class="row" v-if="dateModel.from != '0001-01-01T00:00:00'">
      <div>
        {{ formattedDate }}
      </div>
      <q-space />
      <q-btn
        dense
        round
        flat
        icon="o_close"
        size="12px"
        v-if="hover"
        style="margin: 0px 5px; min-height: 0px"
        @click="cleardates()"
      />
    </div>
    <q-menu
      v-bind:model-value="showdropdown"
      v-bind:no-parent-event="true"
      @hide="showdropdown = false"
    >
      <q-date
        range
        v-model="dateModel"
        @range-end="(range) => assigndate(range)"
      />
    </q-menu>
  </div>
</template>

<style>
.cell {
  height: 100%;
  width: 100%;
}
</style>

<script>
import { ref, computed } from "vue";
import {
  formatMMDD,
  formatDateToSQLString,
} from "../../utils/helpers/dateformatter.js";

export default {
  name: "AssigneeCell",
  emits: ["update-task"],
  props: {
    startDate: {
      type: String,
      default: "0001-01-01T00:00:00",
    },
    endDate: {
      type: String,
      default: "0001-01-01T00:00:00",
    },
  },
  setup(props, { emit }) {
    const hover = ref(false);
    const showdropdown = ref(false);
    const dateModel = ref({ from: props.startDate, to: props.endDate });

    const updatetask = () => {
      emit("update-task", dateModel.value.from, dateModel.value.to);
    };

    const formattedDate = computed(() => {
      const sDate = new Date(dateModel.value.from);
      const eDate = new Date(dateModel.value.to);
      return formatMMDD(sDate) + "-" + formatMMDD(eDate);
    });

    const cleardates = () => {
      dateModel.value.from = "0001-01-01T00:00:00";
      dateModel.value.to = "0001-01-01T00:00:00";
      updatetask();
    };

    const assigndate = (range) => {
      const sDate = new Date(
        range.from.month + " " + range.from.day + " " + range.from.year
      );
      const eDate = new Date(
        range.to.month + " " + range.to.day + " " + range.to.year
      );
      dateModel.value.from = formatDateToSQLString(sDate);
      dateModel.value.to = formatDateToSQLString(eDate);
      showdropdown.value = false;
      updatetask();
    };

    return {
      hover,
      showdropdown,
      dateModel,
      updatetask,
      formattedDate,
      cleardates,
      assigndate,
    };
  },
  updated() {
    this.newstartDate = this.startDate;
    this.newendDate = this.endDate;
  },
};
</script>
