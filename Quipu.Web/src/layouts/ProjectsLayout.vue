<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated>
      <page-header :title="headertitle" :tabs="tabs" :icon="icon" />
    </q-header>

    <nav-menu />

    <q-page-container>
      <router-view :project="project" />
    </q-page-container>
  </q-layout>
</template>

<script>
import PageHeader from "components/PageHeader.vue";
import NavMenu from "components/NavMenu.vue";
import { useRoute } from "vue-router";
import { defineComponent, computed, ref } from "vue";
import { useStore } from "vuex";

export default defineComponent({
  name: "ProjectsLayout",
  components: {
    PageHeader,
    NavMenu,
  },
  setup(props) {
    const route = useRoute();
    const store = useStore();
    const projectisvalid = computed(() => route.params.id !== undefined);
    const project = ref({});

    const getheadertitle = () => {
      if (!projectisvalid.value) {
        return "Projects";
      } else {
        project.value = store.getters.getProjectByID(parseInt(route.params.id));
        return project.value.name;
      }
    };

    const headertitle = computed(() => getheadertitle());

    const projecttabs = [
      {
        title: "Overview",
        link: "/Projects/" + props.projectid,
        disable: false,
        default: true,
      },
      {
        title: "Task List",
        link: "ProjectTaskList",
        disable: false,
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
    const tabs = computed(() => (projectisvalid.value ? projecttabs : []));
    const icon = computed(() =>
      projectisvalid.value ? "mdi-google-circles-group" : ""
    );

    return {
      headertitle,
      tabs,
      icon,
      projectisvalid,
      project,
    };
  },
});
</script>
