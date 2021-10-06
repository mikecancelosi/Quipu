<template>
    <q-header elevated>
        <pageheader :title="project.name"
                    :tabs ="this.tabs"
                    icon ="mdi-google-circles-group"/>     
    </q-header>

    <q-page-container style="padding: 0 0 0 0">
        <router-view :project="this.project" />
    </q-page-container>



</template>

<style scoped>
    .headerText {
        text-align: left;
        margin: 0 0 0 20px
    }
</style>

<script>
    import pageheader from './PageHeader'
    import { RepositoryFactory } from './../repositories/RepositoryFactory'
    const ProjectRepository = RepositoryFactory.get('projects')

    export default {
        name: "ProjectHome",
        props: {
            id: String,
        },
        components: {pageheader},
        data() {
            return {
                project: {},
                tabs: [
                    {
                        title: 'Overview',
                        link: '/Projects/' + this.id + '/Overview',
                        disable: false,
                    },
                    {
                        title: 'Task List',
                        link: '/Projects/' + this.id + '/TaskList',
                        disable: false,
                    },
                    {
                        title: 'Task Board',
                        disable: true
                    },
                    {
                        title: 'Timeline',
                        disable: true,
                    },
                    {
                        title: 'Calendar',
                        disable: true,
                    },
                    {
                        title: 'Dashboard',
                        disable: true,
                    },
                    {
                        title: 'Messages',
                        disable: true,
                    },
                    {
                        title: 'Files',
                        disable: true,
                    },
                ]
            }
        },
        methods: {
            async fetch() {
                this.project = (await ProjectRepository.getProject(this.id)).data;
            },

        },
        mounted() {
            this.fetch().then(() => {
                this.$router.push({ name: "ProjectOverview", params: { project: this.project } });
            })
        }
    }
</script>