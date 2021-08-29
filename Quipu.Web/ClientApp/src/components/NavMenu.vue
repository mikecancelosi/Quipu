<template>
    <header>
        <nav>
            <div class="container">
                <h1>Quipu</h1>
                <div>
                    <ul class="navbar-nav flex-grow">
                        <li class="nav-item">
                            <router-link :to="{ name: 'Home' }" class="nav-link text-dark">Home</router-link>

                        </li>
                        <li class="nav-item">
                            <router-link :to="{ name: 'Projects' }" class="nav-link text-dark">My Tasks</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="{ name: 'Projects' }" class="nav-link text-dark">Inbox</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="{ name: 'Projects' }" class="nav-link text-dark">Projects</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="{ name: 'Projects' }" class="nav-link text-dark">Reporting</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="{ name: 'Projects' }" class="nav-link text-dark">Portfolio</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="{ name: 'Projects' }" class="nav-link text-dark">Goals</router-link>
                        </li>
                    </ul>
                </div>
                <hr />

                <div>
                    <h2>Favorites</h2>
                </div>
                <hr/>

                <div>
                    <h2>Teams</h2>
                </div>
                <hr/>

                <div class="align-bottom">
                    <h2>Help</h2>
                </div>
            </div>
        </nav>
    </header>
</template>


<style scoped>
    .container{
        text-align: left;
        padding: 15px;
        margin: 0 0 0 0;
        max-width: 250px;
        background-color:#555;
    }
    h2{
        font-size:16px;
    }
    .align-bottom{
        position:absolute;
        bottom:10px;
        left:100px;
    }

   
</style>
<script>
    export default {
        name: "NavMenu",
        data() {
            return {
                isExpanded: false
            }
        },
        methods: {
            collapse() {
                this.isExpanded = false;
            },

            toggle() {
                this.isExpanded = !this.isExpanded;
            }
        }
    }
</script>