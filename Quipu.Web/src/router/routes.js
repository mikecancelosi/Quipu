const routes = [
  {
    path: "/",
    name: "Index",
    component: () => import("layouts/MainLayout.vue"),
    children: [
      { path: "", name: "Index", component: () => import("pages/Index.vue") },
    ],
  },
  {
    path: "/Projects",
    name: "Projects",
    component: () => import("layouts/ProjectsLayout.vue"),
    children: [
      {
        path: "",
        name: "ProjectsList",
        component: () => import("pages/Projects"),
      },
      {
        path: ":id",
        name: "ProjectOverview",
        component: () => import("pages/ProjectOverview"),
      },
      {
        path: ":id/TaskList",
        name: "ProjectTaskList",
        component: () => import("pages/ProjectTaskList"),
      },
    ],
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: "/:catchAll(.*)*",
    component: () => import("pages/Error404.vue"),
  },
];

export default routes;
