import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import ProjectsList from "@/components/ProjectsList.vue"
import ProjectItem from "@/components/ProjectItem.vue"
import ProjectCreate from "@/components/ProjectCreate.vue"
import MyTasks from "@/components/MyTasks.vue"
import MyTasksBoard from "@/components/MyTasksBoard.vue"
import MyTasksCalendar from "@/components/MyTasksCalendar.vue"
import MyTasksList from "@/components/MyTasksList.vue"
import TeamCreate from "@/components/TeamCreate.vue"
import TeamHome from "@/components/TeamHome.vue"
import TeamOverview from "@/components/TeamOverview.vue"

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
        path: "/Projects/Create",
        name: "ProjectCreate",
        component: ProjectCreate
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
    },
    {
        path: "/Teams/Create",
        name: "TeamCreate",
        component: TeamCreate
    },
    {
        path: "/Teams/:id",
        name: "TeamHome",
        component: TeamHome,
        props:true,
        children: [
            {
                path: "overview",
                name: "TeamOverview",
                component: TeamOverview,
                props:true,
            }
        ]
    }
   
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;