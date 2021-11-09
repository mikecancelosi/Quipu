<template>
  <div>
    <div v-if="!loading">
      <q-header elevated>
        <pageheader
          :title="project.value.name"
          :tabs="tabs"
          icon="mdi-google-circles-group"
        />
      </q-header>

      <q-page-container style="padding: 0 0 0 0">
        <router-view :project="project.value" />
      </q-page-container>
    </div>
    <q-linear-progress query v-if="loading" />
  </div>
</template>

<style scoped>
.headerText {
  text-align: left;
  margin: 0 0 0 20px;
}
</style>

<script>
import pageheader from "../PageHeader";
import { RepositoryFactory } from "../../repositories/RepositoryFactory";
import { useRouter } from "vue-router";
import { onMounted, reactive, ref } from "vue";
const ProjectRepository = RepositoryFactory.get("projects");

export default {
  name: "ProjectHome",
  props: {
    id: String,
  },
  components: { pageheader },
  setup(props) {
    const project = reactive({});
    const tabs = [
      {
        title: "Overview",
        link: "/Projects/" + props.id + "/Overview",
        disable: false,
      },
      {
        title: "Task List",
        link: "/Projects/" + props.id + "/TaskList",
        disable: false,
        default: true,
      },
      {
        title: "Task Board",
        disable: true,
      },
      {
        title: "Timeline",
        disable: true,
      },
      {
        title: "Calendar",
        disable: true,
      },
      {
        title: "Dashboard",
        disable: true,
      },
      {
        title: "Messages",
        disable: true,
      },
      {
        title: "Files",
        disable: true,
      },
    ];
    const router = useRouter();
    const loading = ref(true);

    const fetch = async () => {
      project.value = (await ProjectRepository.getProject(props.id)).data;
      loading.value = false;
    };

    onMounted(() => {
      fetch().then(() => {
        router.push({
          name: "ProjectTaskList",
          params: { project: project.value },
        });
      });
    });

    return {
      project,
      tabs,
      loading,
      fetch,
    };
  },
};
</script>
