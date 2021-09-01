import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import ProjectsList from "@/components/project-list.vue"
import ProjectItem from "@/components/project-item.vue"
import MyTasks from "@/components/my-tasks.vue"
import MyTasksBoard from "@/components/MyTasksBoard.vue"
import MyTasksCalendar from "@/components/MyTasksCalendar.vue"
import MyTasksList from "@/components/MyTasksList.vue"

const routes = [
    {
        path: "/Home",
        name: "Home",
        component:Home,
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
        children: [
            {
                path: "",
                component: MyTasksList
            },
            {
                path: "board",
                component: MyTasksBoard
            },
            {
                path: "calendar",
                component: MyTasksCalendar
            },
            {
                path: "list",
                component: MyTasksList
            }

        ]
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;