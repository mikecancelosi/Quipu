import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import ProjectsList from "@/components/ProjectsList.vue";
import ProjectCreate from "@/components/ProjectCreate.vue";
import ProjectHome from "@/components/ProjectComponents/ProjectHome.vue";
import ProjectOverview from "@/components/ProjectComponents/ProjectOverview.vue";
import ProjectTaskList from "@/components/ProjectComponents/ProjectTaskList.vue";
import MyTasksHome from "@/components/MyTasksHome.vue";
import MyTasksBoard from "@/components/MyTasksBoard.vue";
import MyTasksCalendar from "@/components/MyTasksCalendar.vue";
import MyTasksList from "@/components/MyTasksList.vue";
import TeamCreate from "@/components/TeamCreate.vue";
import TeamHome from "@/components/TeamHome.vue";
import TeamOverview from "@/components/TeamOverview.vue";
import TeamProjects from "@/components/TeamProjects.vue";

const routes = [
  {
    path: "/Home",
    name: "Home",
    component: Home,
  },
  {
    path: "/Projects",
    name: "Projects",
    component: ProjectsList,
  },
  {
    path: "/Projects/:id",
    name: "ProjectHome",
    component: ProjectHome,
    props: true,
    children: [
      {
        path: "overview",
        name: "ProjectOverview",
        component: ProjectOverview,
        props: true,
      },
      {
        path: "tasklist",
        name: "ProjectTaskList",
        component: ProjectTaskList,
        props: true,
      },
    ],
  },
  {
    path: "/Projects/Create",
    name: "ProjectCreate",
    component: ProjectCreate,
  },
  {
    path: "/MyTasks",
    name: "MyTasksHome",
    component: MyTasksHome,
    children: [
      {
        path: "",
        component: MyTasksList,
      },
      {
        path: "board",
        component: MyTasksBoard,
      },
      {
        path: "calendar",
        component: MyTasksCalendar,
      },
      {
        path: "list",
        component: MyTasksList,
      },
    ],
  },
  {
    path: "/Teams/Create",
    name: "TeamCreate",
    component: TeamCreate,
  },
  {
    path: "/Teams/:id",
    name: "TeamHome",
    component: TeamHome,
    props: true,
    children: [
      {
        path: "overview",
        name: "TeamOverview",
        component: TeamOverview,
        props: true,
      },
      {
        path: "projects",
        name: "TeamProjects",
        component: TeamProjects,
        props: true,
      },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
