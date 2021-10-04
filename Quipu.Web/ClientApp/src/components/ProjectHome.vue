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
    import axios from 'axios'
    import pageheader from './PageHeader'
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
            async getProject() {
                await axios.get('http://127.0.0.1:5000/api/Projects/' + this.id)
                    .then((response) => {
                        this.project = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
        },
        mounted() {
            this.getProject().then(() => {
                this.$router.push({ name: "ProjectOverview", params: { project: this.project } });
            })
        }
    }
</script>