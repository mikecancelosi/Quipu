<template>
  <div class="container">
    <div class="createdtext historicalelement row">
      <div class="col-1">
        <q-avatar color="red" text-color="white" size="35px">M</q-avatar>
      </div>
      <div class="headertext">Michael Cancelosi created this task!</div>
      <div class="datelabel">Sep 7</div>
    </div>

    <div v-if="displayShowExtended">More comments...</div>

    <div
      v-for="reply in elementsToShow"
      :key="reply"
      class="row historicalelement"
    >
      <div class="col-1">
        <q-avatar color="red" text-color="white" size="35px">M</q-avatar>
      </div>
      <div class="headertext">Michael Cancelosi did a thing!!</div>
      <div class="datelabel">Sep 7</div>

      <div class="col-2">
        <div class="row">
          <q-btn icon="o_thumb_down" flat />
        </div>
      </div>
    </div>
  </div>
</template>

<style scope>
.createdtext {
  align-items: center;
}
.container {
  margin: 40px 0px;
  align-content: center;
}

.headertext {
  font-size: 14px;
  font-weight: 600;
}

.datelabel {
  margin: 0px 5px;
  color: rgb(255, 255, 255, 0.5);
  font-size: 12px;
}

.historicalelement {
  min-height: 60px;
  margin: 15px 0px;
}
</style>

<script>
import { reactive, ref, computed } from "vue";
import { adaptTaskRevision } from "../../utils/adapters/taskhistoryadapter.js";

export default {
  name: "Task History",
  props: {
    task: {},
  },
  setup(props) {
    const historicalelements = reactive([]);
    const maxelementcount = 5;
    const showExtended = ref(false);

    props.task.value.revisions.forEach((item) =>
      historicalelements.push(adaptTaskRevision(item))
    );

    const elementsToShow = computed(() => {
      if (!showExtended.value) {
        return historicalelements.slice(-1 * maxelementcount);
      } else {
        return historicalelements.value;
      }
    });

    const displayShowExtended = computed(() => {
      return (
        (historicalelements.value?.length ?? 0) > maxelementcount &&
        !showExtended.value
      );
    });

    return {
      historicalelements,
      maxelementcount,
      showExtended,
      elementsToShow,
      displayShowExtended,
    };
  },
};
</script>
