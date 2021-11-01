<template>
  <q-toolbar id="headingContainer">
    <q-btn
      flat
      dense
      round
      @click="toggleLeftDrawerOpen"
      aria-label="Menu"
      v-show="!this.leftDrawerOpen"
      icon="mdi-forwardburger"
    />
    <div class="row" style="align-items: center">
      <q-btn id="headerIcon" :icon="icon" size="24px" dense flat />
      <a id="headerTitle" :class="{ denseTitle: hasTabs }">
        {{ title }}
      </a>
    </div>

    <q-tabs id="tabsContainer" v-if="hasTabs" v-model="selectedtab" dense>
      <div v-for="tab in tabs" :key="tab">
        <div>
          <q-tab
            class="tabOption"
            :disable="tab.disable"
            :to="tab.link"
            :label="tab.title"
            :name="tab.title"
          />
        </div>
      </div>
    </q-tabs>
  </q-toolbar>
</template>

<style>
#headingContainer {
  height: 70px;
}

#tabsContainer {
  position: absolute;
  bottom: 0;
  left: 70px;
}

#headerIcon {
  margin-right: 15px;
  padding: 0px;
}

#headerTitle {
  font-size: 24px;
}

.denseTitle {
  margin-bottom: 25px;
}
</style>

<script>
import { mapGetters, mapActions } from "vuex";
import { computed, ref } from "vue";
export default {
  name: "PageHeader",
  props: {
    title: String,
    icon: String,
    tabs: Array,
  },
  setup(props) {
    const hasTabs = computed(() => props.tabs?.length ?? 0 > 0);
    const selectedtab = ref();
    if (props.tabs != null) {
      selectedtab.value =
        props.tabs?.find((x) => x.default === true)?.title ?? "";
    }
    return { hasTabs, selectedtab };
  },
  computed: mapGetters(["leftDrawerOpen"]),
  methods: {
    ...mapActions(["toggleLeftDrawerOpen"]),
  },
};
</script>
