<template>
  <div class="container">
    <q-btn
      flat
      v-if="displayShowExtended"
      @click="onDisplayShowExtendedToggled()"
      >More history...</q-btn
    >

    <q-btn
      flat
      v-if="!displayShowExtended"
      @click="onDisplayShowExtendedToggled()"
      >Less history...</q-btn
    >

    <div v-for="reply in elementsToShow" :key="reply" class="historicalelement">
      <div class="row discussionelement" v-if="reply.type === 'Discussion'">
        <div class="col-1">
          <q-avatar color="red" text-color="white" size="35px">{{
            reply.user.display_Name.slice(0, 1)
          }}</q-avatar>
        </div>
        <div class="col">
          <div class="row">
            <div class="headertext">{{ reply.user.display_Name }}</div>
            <div class="datelabel">{{ formatDate(reply.date) }}</div>
          </div>
          <div>{{ reply.display }}</div>
        </div>
        <div class="col-2">
          <div class="row">
            <q-btn icon="o_thumb_up" :ripple="false" flat />
          </div>
        </div>
      </div>

      <div class="row discussionelement" v-if="reply.type === 'Create'">
        <div class="col-1">
          <q-avatar color="red" text-color="white" size="35px">{{
            reply.user.display_Name.slice(0, 1)
          }}</q-avatar>
        </div>

        <div class="col">
          <div class="row">
            <div class="headertext">{{ reply.display }}</div>
            <div class="datelabel">
              {{ formatDate(reply.date) }}
            </div>
          </div>
        </div>

        <div class="col-2">
          <div class="row">
            <q-btn icon="o_thumb_up" :ripple="false" flat />
          </div>
        </div>
      </div>

      <div
        class="row nondiscussionelement"
        v-if="reply.type !== 'Discussion' && reply.type !== 'Create'"
      >
        {{ reply.display }}
        <a style="margin-left: 10px">
          {{ formatDate(reply.date) }}
        </a>
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

.discussionelement {
  min-height: 50px;
}

.discussiontext {
  font-size: 14px;
  color: white;
  font-weight: 500;
}

.historicalelement {
  margin: 15px 0px;
}

.nondiscussionelement {
  color: gray;
}
</style>

<script>
import { reactive, ref, computed } from "vue";
import {
  adaptRevision,
  adaptDiscussion,
} from "../../utils/adapters/taskhistoryadapter.js";

import { formatMonthNameDD } from "../../utils/helpers/dateformatter.js";

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
      historicalelements.push(adaptRevision(item))
    );
    props.task.value.discussions.forEach((item) =>
      historicalelements.push(adaptDiscussion(item))
    );

    historicalelements.sort(function (a, b) {
      if (a.date > b.date) {
        return 1;
      }
      if (a.date === b.date) {
        return 0;
      }
      return -1;
    });

    const formatDate = (date) => {
      return formatMonthNameDD(date);
    };

    const elementsToShow = computed(() => {
      if (!showExtended.value) {
        return historicalelements.slice(-1 * maxelementcount);
      } else {
        return historicalelements;
      }
    });

    const displayShowExtended = computed(() => {
      return (
        (historicalelements?.length ?? 0) > maxelementcount &&
        !showExtended.value
      );
    });

    const onDisplayShowExtendedToggled = () => {
      showExtended.value = !showExtended.value;
    };

    return {
      historicalelements,
      maxelementcount,
      showExtended,
      elementsToShow,
      displayShowExtended,
      onDisplayShowExtendedToggled,
      formatDate,
    };
  },
};
</script>
