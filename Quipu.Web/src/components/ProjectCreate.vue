<template>
  <q-page>
    <q-header>
      <q-toolbar>
        <q-btn
          flat
          dense
          round
          @click="openNav"
          aria-label="Menu"
          v-show="!this.leftDrawerOpen"
          icon="mdi-forwardburger"
        />
      </q-toolbar>
    </q-header>

    <div id="page-container">
      <h1>New Project</h1>
      <q-input color="teal" filled label="Name" />
      <q-space />
      <q-input color="teal" filled label="Description" type="textarea" />
      <q-space />
      <div class="row">
        <q-select
          outlined
          label="Privacy"
          v-model="selectedprivacy"
          :options="privacyoptions"
          color="teal"
          style="width: 45%"
        />
        <q-space style="width: 10%" />
        <q-select
          outlined
          label="Team Owner"
          color="teal"
          :options="teams"
          v-model="selectedteam"
          style="width: 45%"
        />
      </div>
      <q-space />
      <div class="row">
        <q-space />
        <q-btn label="Create project" color="teal" disable />
      </div>
    </div>
  </q-page>
</template>

<style scoped>
#page-container {
  position: relative;
  width: 100%;
  height: 100%;
  padding: 100px 300px;
}
.q-header {
  background-color: transparent;
}
h1 {
  font-size: 32px;
}
.q-space {
  height: 25px;
}
</style>

<script>
import { ref } from "vue";
export default {
  name: "ProjectCreate",
  props: {
    leftDrawerOpen: Boolean,
    teams: [],
  },
  data() {
    return {
      selectedprivacy: ref("Private"),
      selectedteam: "",
      privacyoptions: ["Private", "Public"],
    };
  },
  methods: {
    openNav() {
      this.$emit("open-nav");
    },
  },
  mounted() {},
};
</script>
