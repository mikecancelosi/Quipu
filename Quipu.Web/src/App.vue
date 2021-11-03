<template>
  <q-layout view="lHh Lpr lFf">
    <q-drawer v-model="leftDrawerOpen" show-if-above bordered>
      <navmenu />
    </q-drawer>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<style>
body.desktop .q-focusable:focus .q-focus-helper,
body.desktop .q-hoverable:hover .q-focus-helper {
  opacity: 0 !important;
} /*remove button hover*/

.q-header .q-tab__content {
  min-width: 0px !important;
}

.q-textarea .q-field__native {
  padding-top: 5px !important;
}
</style>

<script>
import { mapActions } from "vuex";
import navmenu from "./components/NavMenu";
import { mapGetters } from "vuex";

export default {
  name: "LayoutDefault",
  components: { navmenu },
  computed: mapGetters(["leftDrawerOpen"]),
  created() {
    this.fetchStatusTypes();
    this.fetchPriorityTypes();
    this.fetchTaskStatusCategories();
    this.fetchTasks();
    this.fetchUsers();
    this.fetchProjects();
  },
  mounted() {
    this.$router.push("/Home");
  },
  methods: {
    ...mapActions([
      "fetchStatusTypes",
      "fetchPriorityTypes",
      "fetchTaskStatusCategories",
      "fetchTasks",
      "fetchUsers",
      "fetchProjects",
    ]),
  },
};
</script>
