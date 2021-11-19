<template>
  <router-view />
</template>
<script>
import { defineComponent } from "vue";
import { useStore } from "vuex";

export default defineComponent({
  name: "App",
  setup() {
    const store = useStore();
    store.dispatch("fetchStatusTypes");
    store.dispatch("fetchPriorityTypes");
    store.dispatch("fetchTaskStatusCategories");
    store.dispatch("fetchTasks");
    store.dispatch("fetchUsers");
    store.dispatch("fetchProjects");
  },
});
</script>
