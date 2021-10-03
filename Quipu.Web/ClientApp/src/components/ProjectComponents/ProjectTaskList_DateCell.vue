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
                {{formattedDate}}
            </div>
            <q-space />
            <q-btn dense
                   round
                   flat
                   icon="o_close"
                   size="12px"                   
                   v-if="hover"
                   style="margin:0px 5px; min-height:0px;"
                   @click="cleardates();" />
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
        props: ['startDate', 'endDate'],
        computed: {
            formattedDate() {
                return this.formatdate(this.newstartDate, this.newendDate)
            }
        },
        data() {
            return {
                hover: false, 
                showdropdown: false,
                newstartDate: this.startDate,
                newendDate: this.endDate,
            }
        },
        methods: {            
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
                this.updatetask();
            },
            cleardates() {
                this.newstartDate = '0001-01-01T00:00:00';
                this.newDate = '0001-01-01T00:00:00';
                this.updatetask();
            },
           
        },
        updated() {
            this.newstartDate = this.startDate;
            this.newendDate = this.endDate;
        }

    }
</script>