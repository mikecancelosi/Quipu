<template>
    <div class="cell" 
         @mouseenter="hover = true"
         @mouseleave="hover = false">
        <q-btn icon="o_calendar_today"
               round
               flat
               outline
               dense
               size="10px"
               v-if="hover &&
                     !showdropdown &&
                     newstartDate == '0001-01-01T00:00:00'"
               @click="showdropdown = true; "
               :style="{visibility: newstartDate == '0001-01-01T00:00:00'
                                                       ? 'visible'
                                                       : 'collapse'}">

        </q-btn>

        <div class="row" v-if="newstartDate != '0001-01-01T00:00:00'">
            <div>
                {{formatdate(newstartDate,newendDate)}}
            </div>
            <q-space />
            <q-btn dense
                   round
                   flat
                   icon="o_close"
                   v-if="hover"
                   size="12px"
                   style="margin:5px;"
                   @click="cleardates(element);" />
        </div>
        <q-menu v-bind:model-value="showdropdown"
                v-bind:no-parent-event="true"
                @hide="showdropdown=false">
            <q-date range
                    v-model="dates"
                    @range-end="(range)=>assigndate(range)" />
        </q-menu>
    </div>
</template>

<style>
    .cell {
        height: 100%;
        width: 100%;
    }
</style>

<script>
    export default {
        name: "AssigneeCell",
        emits: ["update-task"],
        props: {
            task: {},
            users: [],
            useroptions: [],
        },
        data() {
            return {
                hover: false,
                showdropdown: false,
                newstartDate: this.task.startDate,
                newendDate: this.task.endDate,
                dates: {},
            }
        },
        methods: {
            assignUserClicked() {
                this.showdropdown = true;
                this.$nextTick(() => { this.$refs.userselect.showPopup() });
            },
            updatetask() {
                this.$emit("update-task", this.newstartdate, this.newenddate);
            },
            formatdate(startDate, endDate) {
                var sDate = new Date(startDate);
                var eDate = new Date(endDate);             
                return sDate.getMonth() + "/" + sDate.getDate() + "-" +
                    eDate.getMonth() + "/" + eDate.getDate();
            },
            assigndate(range) {
                this.newstartDate = new Date(range.from.month + " " + range.from.day + " " + range.from.year);
                this.newendDate = new Date(range.to.month + " " + range.to.day + " " + range.to.year);
                console.log(this.newstartDate);
                console.log(this.newendDate);
                this.updatetask();
            },
            cleardates(task) {
                this.newstartDate = '0001-01-01T00:00:00';
                this.newDate = '0001-01-01T00:00:00';
                task.dates = {};
                this.updatetask(task);
            },
            mounted() {
            },
        },

    }
</script>