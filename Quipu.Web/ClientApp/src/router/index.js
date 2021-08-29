import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import ProjectsList from "@/components/project-list.vue"
import ProjectItem from "@/components/project-item.vue"
import MyTasks from "@/components/my-tasks.vue"

const routes = [
    {
        path: "/",
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
        name: "ProjectItem",
        component: ProjectItem,
        props:true
    },
    {
        path: "/MyTasks",
        name: "MyTasks",
        component: MyTasks,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;