<template>
  <q-header elevated>
    <pageheader title="Projects" icon="o_groups" />
  </q-header>
  <q-separator />

  <div id="contentContainer">
    <q-space />
    <div class="row">
      <q-btn icon="o_add" label="Add Project" push color="primary" />
      <q-space />
      <q-btn-dropdown color="primary" label="Sort" icon="o_filter_list" dense>
        <q-item clickable v-close-popup @click="onItemClick">
          <q-item-section>
            <q-item-label>None</q-item-label>
          </q-item-section>
        </q-item>

        <q-item clickable v-close-popup @click="onItemClick">
          <q-item-section>
            <q-item-label>Due Date</q-item-label>
          </q-item-section>
        </q-item>

        <q-item clickable v-close-popup @click="onItemClick">
          <q-item-section>
            <q-item-label>Alphabetical</q-item-label>
          </q-item-section>
        </q-item>
      </q-btn-dropdown>
    </div>
    <q-space />

    <q-table
      :rows="projects"
      :columns="columns"
      :loading="loading"
      @row-dblclick="navigateToProject"
      id="projectTable"
    />
  </div>
</template>

<style scoped>
#contentContainer {
  padding: 20px;
}

#projectTable {
  margin-top: 10px;
}
</style>

<script>
import { ref, computed } from "vue";
import pageheader from "./PageHeader";
import { useStore } from "vuex";
import { useRouter } from "vue-router";

export default {
  name: "ProjectsList",
  components: { pageheader },
  setup() {
    const columns = [
      { name: "name", label: "Project Name", field: "name", align: "left" },
      { name: "status", label: "Status", field: "status", align: "left" },
      {
        name: "priority",
        label: "Priority",
        field: "priority",
        align: "left",
      },
    ];
    const pagination = ref({
      sortBy: "desc",
      descending: false,
      page: 1,
      rowsPerPage: 10,
      rowsNumber: 10,
    });
    const store = useStore();
    const loading = computed(() => (projects.value?.length ?? 0) <= 0);
    const projects = computed(() => store.getters.getProjects);
    const router = useRouter();

    const navigateToProject = (evt, row) => {
      router.push({
        name: "ProjectHome",
        params: { id: row.id },
      });
    };

    return { columns, projects, pagination, loading, navigateToProject };
  },
};
</script>
